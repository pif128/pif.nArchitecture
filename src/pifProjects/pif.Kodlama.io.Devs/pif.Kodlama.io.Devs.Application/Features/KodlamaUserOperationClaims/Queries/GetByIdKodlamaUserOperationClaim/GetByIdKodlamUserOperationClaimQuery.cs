using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Dtos;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;

namespace pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Queries.GetByIdKodlamaUserOperationClaim
{
	public class GetByIdKodlamUserOperationClaimQuery : IRequest<GetByIdKodlamaUserOperationClaimDto>
	{
		public int Id { get; set; }

		public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdKodlamUserOperationClaimQuery, GetByIdKodlamaUserOperationClaimDto>
		{
			private readonly IKodlamaUserOperationClaimRepository _kodlamaUserOperationClaimRepository;
			private readonly IMapper _mapper;
			private readonly KodlamaUserOperationClaimBusinessRule _kodlamaUserOperationClaimBusinessRule;

			public GetByIdUserOperationClaimQueryHandler(IKodlamaUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, KodlamaUserOperationClaimBusinessRule kodlamaUserOperationClaimBusinessRule)
			{
				_kodlamaUserOperationClaimRepository = userOperationClaimRepository;
				_mapper = mapper;
				_kodlamaUserOperationClaimBusinessRule = kodlamaUserOperationClaimBusinessRule;
			}

			public async Task<GetByIdKodlamaUserOperationClaimDto> Handle(GetByIdKodlamUserOperationClaimQuery request, CancellationToken cancellationToken)
			{
				await _kodlamaUserOperationClaimBusinessRule.UserOperationClaimShoultExistWhenRequest(request.Id);

				UserOperationClaim userOperationClaim = await _kodlamaUserOperationClaimRepository.GetAsync(x => x.Id == request.Id,
					include: x => x.Include(c => c.User).Include(c => c.OperationClaim));

				GetByIdKodlamaUserOperationClaimDto getByIdUserOperationClaimDto = _mapper.Map<GetByIdKodlamaUserOperationClaimDto>(userOperationClaim);

				return getByIdUserOperationClaimDto;
			}
		}
	}
}
