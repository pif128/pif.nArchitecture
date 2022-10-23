using pif.Core.CrossCuttingConcerns.Exceptions;
using pif.Core.Persistence.Paging;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Rules
{
	public class GithubProfileBusinessRule
	{
		private readonly IGithubProfileRepository _githubProfileRepository;
		private readonly IKodlamaUserRepository _userRepository;

		public GithubProfileBusinessRule(IGithubProfileRepository githubProfileRepository, IKodlamaUserRepository userRepository)
		{
			_githubProfileRepository = githubProfileRepository;
			_userRepository = userRepository;
		}

		//public async Task GithubAddressCannotBeDuplicateYourProfileWhenInserted(string githubAddress, int UserId)
		//{
		//	GithubProfile githubProfile = await _githubProfileRepository.GetAsync(x => x.UserId == UserId && x.GithubAddress == githubAddress);
		//	if (githubProfile != null) throw new BusinessException("This profile address alreadey been added to your profile");
		//}
		public async Task GithubAddressCannotBeDuplicateWhenInserted(string githubAddress)
		{
			var githubProfile = await _githubProfileRepository.GetAsync(x => x.GithubAddress == githubAddress);
			if (githubProfile != null) throw new BusinessException("Github address exists.");
		}

		public async Task GithubAddressShouldBeUserIdWhenInserted(int? userId)
		{
			var result = await _userRepository.GetAsync(x => x.Id == userId);
			if (result == null) throw new BusinessException("User does not exist.");

		}
		public async Task GithubAddressCannotBeDuplicateWhenUpdated(string githubAddress)
		{
			IPaginate<GithubProfile> result = await _githubProfileRepository.GetListAsync(b => b.GithubAddress == githubAddress);
			if (result.Items.Count > 1) throw new BusinessException("Github address already exists.");
		}
		public async Task GithubAddressShouldBeUserIdWhenUpdated(int? userId)
		{
			var result = await _userRepository.GetListAsync(x => x.Id == userId);
			if (result == null) throw new BusinessException("User does not exist.");

		}

		public void GithubProfileShouldExistWhenRequested(GithubProfile? githubProfile)
		{
			if (githubProfile == null) throw new BusinessException("Github Profile does not exist.");
		}
		public async Task GithubProfileShouldExistWhenDeleted(int? id)
		{
			GithubProfile? result = await _githubProfileRepository.GetAsync(x => x.Id == id);
			if (result == null) throw new BusinessException("Github Profile does not exist.");

		}
	}
}
