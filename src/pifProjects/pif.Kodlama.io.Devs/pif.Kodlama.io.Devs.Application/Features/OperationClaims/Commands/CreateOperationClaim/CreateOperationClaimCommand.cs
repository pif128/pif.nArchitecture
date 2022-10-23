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

namespace pif.Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
	public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
	{
		public string Name { get; set; }
		public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
		{
			private readonly IOperationClaimRepository _operationClaimRepository;
			private readonly IMapper _mapper;
			private readonly OperationClaimBusinessRule _operationClaimBusinessRule;

			public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRule operationClaimBusinessRule)
			{
				_operationClaimRepository = operationClaimRepository;
				_mapper = mapper;
				_operationClaimBusinessRule = operationClaimBusinessRule;
			}

			public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
			{
				await _operationClaimBusinessRule.OperationClaimCannotBeDuplicateWhenInserted(request.Name);

				OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
				OperationClaim operationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);

				CreatedOperationClaimDto createdOperationClaimDto = _mapper.Map<CreatedOperationClaimDto>(mappedOperationClaim);
				return createdOperationClaimDto;
			}
		}
	}
}
