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

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile
{
	public class CreateGithubProfileCommand : IRequest<CreatedGithubProfileDto>
	{
		public string GithubAddress { get; set; }
		public int UserId { get; set; }

		public class CreateGithubProfileCommandHandler : IRequestHandler<CreateGithubProfileCommand, CreatedGithubProfileDto>
		{
			private readonly IGithubProfileRepository _githubProfileRepository;
			private readonly IMapper _mapper;
			private readonly GithubProfileBusinessRule _githubProfileBusinessRule;

			public CreateGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRule githubProfileBusinessRule)
			{
				_githubProfileRepository = githubProfileRepository;
				_mapper = mapper;
				_githubProfileBusinessRule = githubProfileBusinessRule;
			}

			public async Task<CreatedGithubProfileDto> Handle(CreateGithubProfileCommand request, CancellationToken cancellationToken)
			{
				await _githubProfileBusinessRule.GithubAddressCannotBeDuplicateWhenInserted(request.GithubAddress);
				await _githubProfileBusinessRule.GithubAddressShouldBeUserIdWhenInserted(request.UserId);

				GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);
				GithubProfile addedGithubProfile = await _githubProfileRepository.AddAsync(mappedGithubProfile);

				CreatedGithubProfileDto createdGithubProfileDto = _mapper.Map<CreatedGithubProfileDto>(addedGithubProfile);

				return createdGithubProfileDto;


			}
		}
	}
}
