using AutoMapper;
using MediatR;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Dtos;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
	public class GetByIdOperationClaimQuery : IRequest<GetByIdOperationClaimDto>
	{
		public int Id { get; set; }
		public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, GetByIdOperationClaimDto>
		{
			private readonly IOperationClaimRepository _operationClaimRepository;
			private readonly IMapper _mapper;
			private readonly OperationClaimBusinessRule _operationClaimBusinessRule;

			public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRule operationClaimBusinessRule)
			{
				_operationClaimRepository = operationClaimRepository;
				_mapper = mapper;
				_operationClaimBusinessRule = operationClaimBusinessRule;
			}

			public async Task<GetByIdOperationClaimDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
			{
				OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
				_operationClaimBusinessRule.OperationClaimShouldExistWhenRequested(operationClaim);
				GetByIdOperationClaimDto getByIdOperationClaimDto = _mapper.Map<GetByIdOperationClaimDto>(operationClaim);
				return getByIdOperationClaimDto;

			}
		}
	}
}
