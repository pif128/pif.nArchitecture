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

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
	public class UpdateGithubProfileCommand : IRequest<UpdatedGithubProfileDto>
	{
		public int Id { get; set; }
		public string GithubAddress { get; set; }
		public int UserId { get; set; }
		public class UpdateGithubProfileCommandHandler : IRequestHandler<UpdateGithubProfileCommand, UpdatedGithubProfileDto>
		{
			private readonly IGithubProfileRepository _githubProfileRepository;
			private readonly IMapper _mapper;
			private readonly GithubProfileBusinessRule _githubProfileBusinessRule;

			public UpdateGithubProfileCommandHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper, GithubProfileBusinessRule githubProfileBusinessRule)
			{
				_githubProfileRepository = githubProfileRepository;
				_mapper = mapper;
				_githubProfileBusinessRule = githubProfileBusinessRule;
			}

			public async Task<UpdatedGithubProfileDto> Handle(UpdateGithubProfileCommand request, CancellationToken cancellationToken)
			{
				await _githubProfileBusinessRule.GithubAddressCannotBeDuplicateWhenUpdated(request.GithubAddress);
				await _githubProfileBusinessRule.GithubAddressShouldBeUserIdWhenUpdated(request.UserId);

				GithubProfile mappedGithubProfile = _mapper.Map<GithubProfile>(request);
				GithubProfile updatedGithubProfile = await _githubProfileRepository.UpdateAsync(mappedGithubProfile);
				UpdatedGithubProfileDto updatedGithubProfileDto = _mapper.Map<UpdatedGithubProfileDto>(updatedGithubProfile);
				return updatedGithubProfileDto;

			}
		}
	}
}
