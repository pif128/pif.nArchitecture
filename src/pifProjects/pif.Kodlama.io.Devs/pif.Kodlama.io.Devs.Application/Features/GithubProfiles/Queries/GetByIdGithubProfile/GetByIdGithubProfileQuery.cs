using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Queries.GetByIdGithubProfile
{
	public class GetByIdGithubProfileQuery : IRequest<GetByIdGithubProfileDto>
	{
		public int Id { get; set; }
		public class GetByIdGithubProfileQueryHandler : IRequestHandler<GetByIdGithubProfileQuery, GetByIdGithubProfileDto>
		{
			private readonly IGithubProfileRepository _githubProfileRepository;
			private readonly IMapper _mapper;
			private readonly GithubProfileBusinessRule _githubProfileBusinessRule;

			public GetByIdGithubProfileQueryHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRule githubProfileBusinessRule)
			{
				_githubProfileRepository = githubProfileRepository;
				_mapper = mapper;
				_githubProfileBusinessRule = githubProfileBusinessRule;
			}

			public async Task<GetByIdGithubProfileDto> Handle(GetByIdGithubProfileQuery request, CancellationToken cancellationToken)
			{
				GithubProfile? githubProfile = _githubProfileRepository.Get(x => x.Id == request.Id,
					include: x => x.Include(c => c.User));
				_githubProfileBusinessRule.GithubProfileShouldExistWhenRequested(githubProfile);

				GetByIdGithubProfileDto getByIdGithubProfileDto = _mapper.Map<GetByIdGithubProfileDto>(githubProfile);

				return getByIdGithubProfileDto;

			}
		}
	}
}
