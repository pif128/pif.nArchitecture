using AutoMapper;
using MediatR;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
	public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>
	{
		public int Id { get; set; }
		public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
		{
			private readonly IOperationClaimRepository _operationClaimRepository;
			private readonly IMapper _mapper;
			private readonly OperationClaimBusinessRule _operationClaimBusinessRule;

			public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRule operationClaimBusinessRule)
			{
				_operationClaimRepository = operationClaimRepository;
				_mapper = mapper;
				_operationClaimBusinessRule = operationClaimBusinessRule;
			}

			public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
			{
				await _operationClaimBusinessRule.OperationClaimShouldExistWhenDeleted(request.Id);
				OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
				OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(mappedOperationClaim);
				DeletedOperationClaimDto deletedOperationClaimDto = _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);

				return deletedOperationClaimDto;
			}
		}
	}
}
