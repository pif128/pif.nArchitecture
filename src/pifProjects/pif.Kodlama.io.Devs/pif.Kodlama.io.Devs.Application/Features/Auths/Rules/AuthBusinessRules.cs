using MediatR;
using pif.Core.CrossCuttingConcerns.Exceptions;
using pif.Core.Security.Entities;
using pif.Core.Security.Hashing;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Auths.Rules
{
	public class AuthBusinessRules
	{
		private readonly IKodlamaUserRepository _kodlamaUserRepository;

		public AuthBusinessRules(IKodlamaUserRepository kodlamaUserRepository)
		{
			_kodlamaUserRepository = kodlamaUserRepository;
		}

		public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
		{
			User? user = await _kodlamaUserRepository.GetAsync(u => u.Email == email);
			if (user != null) throw new BusinessException("Mail already exists");

		}
		public async Task UserNameCanNotBeDuplicatedWhenRegistered(string userName)
		{
			User? user = await _kodlamaUserRepository.GetAsync(u => u.UserName == userName);
			if (user != null) throw new BusinessException("User name already exists");

		}
		public async Task CheckKodlamaUserWhenLogin(KodlamaUser kodlamaUser)
		{
			if (kodlamaUser == null) throw new BusinessException("username or password is incorrect");
		}
		public async Task CheckKodlamaUserPasswordWhenLogin(bool verify)
		{
			if (!verify) throw new BusinessException("username or password is incorrect");
		}
	}
}
