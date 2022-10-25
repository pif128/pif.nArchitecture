using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pif.Core.Application.Requests;
using pif.Core.Persistence.Paging;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Models;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Queries.GetListKodlamaUserOperationClaim
{
	public class GetListKodlamaUserOperationClaimQuery : IRequest<KodlamaUserOperationClaimListModel>
	{
		public PageRequest PageRequest { get; set; }

		public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListKodlamaUserOperationClaimQuery, KodlamaUserOperationClaimListModel>
		{
			private readonly IKodlamaUserOperationClaimRepository _userOperationClaimRepository;
			private readonly IMapper _mapper;

			public GetListUserOperationClaimQueryHandler(IKodlamaUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
			{
				_userOperationClaimRepository = userOperationClaimRepository;
				_mapper = mapper;
			}

			public async Task<KodlamaUserOperationClaimListModel> Handle(GetListKodlamaUserOperationClaimQuery request, CancellationToken cancellationToken)
			{
				IPaginate<KodlamaUserOperationClaim> kodlamaUserOperationClaims = await _userOperationClaimRepository.GetListAsync(include: x => x.Include(c => c.User).Include(c => c.OperationClaim),
					index: request.PageRequest.Page,
					size: request.PageRequest.PageSize);
				KodlamaUserOperationClaimListModel mappedKodlamaUserOperationClaimListModel = _mapper.Map<KodlamaUserOperationClaimListModel>(kodlamaUserOperationClaims);

				return mappedKodlamaUserOperationClaimListModel;

			}
		}
	}
}
