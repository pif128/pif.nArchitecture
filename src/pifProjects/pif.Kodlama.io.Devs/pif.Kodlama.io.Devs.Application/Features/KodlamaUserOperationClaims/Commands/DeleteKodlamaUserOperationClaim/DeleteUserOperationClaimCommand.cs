using AutoMapper;
using MediatR;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Dtos;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Commands.DeleteKodlamaUserOperationClaim
{
	public class DeleteKodlamaUserOperationClaimCommand : IRequest<DeletedKodlamaUserOperationClaimDto>
	{
		public int Id { get; set; }
		public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteKodlamaUserOperationClaimCommand, DeletedKodlamaUserOperationClaimDto>
		{
			private readonly IKodlamaUserOperationClaimRepository _kodlamaUserOperationClaimRepository;
			private readonly IMapper _mapper;
			private readonly KodlamaUserOperationClaimBusinessRule _kodlamaUserOperationClaimBusinessRule;

			public DeleteUserOperationClaimCommandHandler(IKodlamaUserOperationClaimRepository kodlamaUserOperationClaimRepository, IMapper mapper, KodlamaUserOperationClaimBusinessRule kodlamaUserOperationClaimBusinessRule)
			{
				_kodlamaUserOperationClaimRepository = kodlamaUserOperationClaimRepository;
				_mapper = mapper;
				_kodlamaUserOperationClaimBusinessRule = kodlamaUserOperationClaimBusinessRule;
			}

			async Task<DeletedKodlamaUserOperationClaimDto> IRequestHandler<DeleteKodlamaUserOperationClaimCommand, DeletedKodlamaUserOperationClaimDto>.Handle(DeleteKodlamaUserOperationClaimCommand request, CancellationToken cancellationToken)
			{
				await _kodlamaUserOperationClaimBusinessRule.UserOperationClaimShoultExistWhenDeleted(request.Id);
				UserOperationClaim userOperationClaim = await _kodlamaUserOperationClaimRepository.GetAsync(x => x.Id == request.Id);
				DeletedKodlamaUserOperationClaimDto deletedUserOperationClaimDto = _mapper.Map<DeletedKodlamaUserOperationClaimDto>(userOperationClaim);

				return deletedUserOperationClaimDto;
			}
		}
	}
}
