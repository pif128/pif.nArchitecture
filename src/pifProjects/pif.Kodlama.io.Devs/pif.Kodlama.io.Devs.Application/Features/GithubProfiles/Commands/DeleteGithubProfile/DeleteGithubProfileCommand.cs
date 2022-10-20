using AutoMapper;
using MediatR;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Rules;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile
{
	public class DeleteGithubProfileCommand:IRequest<DeletedGithubProfileDto>
	{
		public int Id { get; set; }

		public class DeleteGithubProfileCommandHandler : IRequestHandler<DeleteGithubProfileCommand, DeletedGithubProfileDto>
		{
			private readonly IGithubProfileRepository _githubProfileRepository;
			private readonly IMapper _mapper;
			private readonly GithubProfileBusinessRule _githubProfileBusinessRule;

			public DeleteGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRule githubProfileBusinessRule)
			{
				_githubProfileRepository = githubProfileRepository;
				_mapper = mapper;
				_githubProfileBusinessRule = githubProfileBusinessRule;
			}

			public async Task<DeletedGithubProfileDto> Handle(DeleteGithubProfileCommand request, CancellationToken cancellationToken)
			{
				GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);
				GithubProfile deletedGithubProfile =await _githubProfileRepository.DeleteAsync(mappedGithubProfile);
				DeletedGithubProfileDto deletedGithubProfileDto=_mapper.Map<DeletedGithubProfileDto>(deletedGithubProfile);
				return deletedGithubProfileDto;
			}
		}
	}
}
