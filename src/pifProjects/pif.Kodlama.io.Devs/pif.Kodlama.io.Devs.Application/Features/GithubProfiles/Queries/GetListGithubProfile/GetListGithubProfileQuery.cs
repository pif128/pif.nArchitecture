using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pif.Core.Application.Requests;
using pif.Core.Persistence.Paging;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Models;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Models;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Queries.GetListGithubProfile
{
	public class GetListGithubProfileQuery:IRequest<GithubProfileListModel>
	{
		public PageRequest PageRequest { get; set; }

		public class GetListGithubProfileQueryHandler : IRequestHandler<GetListGithubProfileQuery, GithubProfileListModel>
		{
			private readonly IGithubProfileRepository _githubProfileRepository;
			private readonly IMapper _mapper;

			public GetListGithubProfileQueryHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper)
			{
				_githubProfileRepository = githubProfileRepository;
				_mapper = mapper;
			}

			public async Task<GithubProfileListModel> Handle(GetListGithubProfileQuery request, CancellationToken cancellationToken)
			{
				IPaginate<GithubProfile> githubProfiles = await _githubProfileRepository.GetListAsync(
					include:
					x => x.Include(c => c.User),
					index: request.PageRequest.Page, size: request.PageRequest.PageSize);

				GithubProfileListModel mappedGithubProfileListModel = _mapper.Map<GithubProfileListModel>(githubProfiles);

				return mappedGithubProfileListModel;
			}
		}
	}
}
