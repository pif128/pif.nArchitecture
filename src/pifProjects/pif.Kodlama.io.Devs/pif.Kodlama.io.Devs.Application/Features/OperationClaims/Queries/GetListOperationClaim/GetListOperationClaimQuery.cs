using AutoMapper;
using MediatR;
using pif.Core.Application.Requests;
using pif.Core.Persistence.Paging;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Models;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim
{
	public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>
	{
		public PageRequest PageRequest { get; set; }

		public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
		{
			private readonly IOperationClaimRepository _operationClaimRepository;
			private readonly IMapper _mapper;

			public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
			{
				_operationClaimRepository = operationClaimRepository;
				_mapper = mapper;
			}

			public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
			{
				IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
				OperationClaimListModel mappedOperationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);
				return mappedOperationClaimListModel;
			}
		}
	}
}
