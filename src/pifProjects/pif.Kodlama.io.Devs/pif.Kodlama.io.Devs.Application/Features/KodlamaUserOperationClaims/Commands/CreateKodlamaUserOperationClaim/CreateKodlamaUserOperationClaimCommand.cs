using AutoMapper;
using MediatR;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Dtos;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.CreateKodlamaUserOperationClaim
{
	public class CreateKodlamaUserOperationClaimCommand : IRequest<CreatedKodlamaUserOperationClaimDto>
	{
		public int UserId { get; set; }
		public int OperationClaimId { get; set; }
		public class CreateKodlamaUserOperationClaimCommandHandler : IRequestHandler<CreateKodlamaUserOperationClaimCommand, CreatedKodlamaUserOperationClaimDto>
		{
			private readonly IMapper _mapper;
			private readonly IKodlamaUserOperationClaimRepository _kodlamaUserOperationClaimRepository;
			private readonly KodlamaUserOperationClaimBusinessRule _kodlamaUserOperationClaimBusinessRule;

			public CreateKodlamaUserOperationClaimCommandHandler(IMapper mapper, IKodlamaUserOperationClaimRepository kodlamaUserOperationClaimRepository, KodlamaUserOperationClaimBusinessRule kodlamaUserOperationClaimBusinessRule)
			{
				_mapper = mapper;
				_kodlamaUserOperationClaimRepository = kodlamaUserOperationClaimRepository;
				_kodlamaUserOperationClaimBusinessRule = kodlamaUserOperationClaimBusinessRule;
			}

			public async Task<CreatedKodlamaUserOperationClaimDto> Handle(CreateKodlamaUserOperationClaimCommand request, CancellationToken cancellationToken)
			{
				await _kodlamaUserOperationClaimBusinessRule.OperationClaimShoultExistWhenInserted(request.OperationClaimId);
				await _kodlamaUserOperationClaimBusinessRule.UserShoultExistWhenInserted(request.UserId);
				await _kodlamaUserOperationClaimBusinessRule.UserOperationClaimCanNotBeDuplicatedWhenInserted(request.UserId, request.OperationClaimId);

				KodlamaUserOperationClaim mappedUserOperationClaim = _mapper.Map<KodlamaUserOperationClaim>(request);
				KodlamaUserOperationClaim createdKodlamaUserOperationClaim = await _kodlamaUserOperationClaimRepository.AddAsync(mappedUserOperationClaim);
				CreatedKodlamaUserOperationClaimDto createdKodlamaUserOperationClaimDto = _mapper.Map<CreatedKodlamaUserOperationClaimDto>(createdKodlamaUserOperationClaim);

				return createdKodlamaUserOperationClaimDto;
			}
		}
	}
}
