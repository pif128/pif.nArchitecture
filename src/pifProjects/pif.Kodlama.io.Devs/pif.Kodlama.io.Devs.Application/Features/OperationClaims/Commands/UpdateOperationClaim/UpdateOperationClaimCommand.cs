using AutoMapper;
using MediatR;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
	public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
		{
			private readonly IOperationClaimRepository _operationClaimRepository;
			private readonly IMapper _mapper;
			private readonly OperationClaimBusinessRule _operationClaimBusinessRule;

			public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRule operationClaimBusinessRule)
			{
				_operationClaimRepository = operationClaimRepository;
				_mapper = mapper;
				_operationClaimBusinessRule = operationClaimBusinessRule;
			}

			public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
			{
				await _operationClaimBusinessRule.OperationClaimCannotBeDuplicateWhenUpdated(request.Name);

				OperationClaim mappedOperationClaim=_mapper.Map<OperationClaim>(request);
				OperationClaim updatedOperationClaim =await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
				UpdatedOperationClaimDto updatedOperationClaimDto=_mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);

				return updatedOperationClaimDto;
			}
		}
	}
}
