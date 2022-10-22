using MediatR;
using pif.Core.Security.Dtos;
using pif.Core.Security.Entities;
using pif.Core.Security.Hashing;
using pif.Core.Security.JWT;
using pif.Kodlama.io.Devs.Application.Features.Auths.Dtos;
using pif.Kodlama.io.Devs.Application.Features.Auths.Rules;
using pif.Kodlama.io.Devs.Application.Services.AuthService;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Features.Auths.Commands.RegisterKodlamaUser
{
	public class RegisterKodlamaUserCommand : IRequest<RegisteredDto>
	{
		public KodlamaUserForRegisterDto KodlamaUserForRegisterDto { get; set; }
		public string IpAddress { get; set; }

		public class RegisterKodlamaUserCommandHandler : IRequestHandler<RegisterKodlamaUserCommand, RegisteredDto>
		{
			private readonly IKodlamaUserRepository _kodlamaUserRepository;
			private readonly IAuthService _authService;
			private readonly AuthBusinessRules _authBusinessRules;

			public RegisterKodlamaUserCommandHandler(IKodlamaUserRepository kodlamaUserRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
			{
				_kodlamaUserRepository = kodlamaUserRepository;
				_authService = authService;
				_authBusinessRules = authBusinessRules;
			}

			public async Task<RegisteredDto> Handle(RegisterKodlamaUserCommand request, CancellationToken cancellationToken)
			{
				await _authBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(request.KodlamaUserForRegisterDto.Email);
				await _authBusinessRules.UserNameCanNotBeDuplicatedWhenRegistered(request.KodlamaUserForRegisterDto.UserName);

				byte[] passwordHash, passwordSalt;
				HashingHelper.CreatePasswordHash(request.KodlamaUserForRegisterDto.Password, out passwordHash, out passwordSalt);

				KodlamaUser newUser = new()
				{
					Email = request.KodlamaUserForRegisterDto.Email,
					PasswordHash = passwordHash,
					PasswordSalt = passwordSalt,
					FirstName = request.KodlamaUserForRegisterDto.FirstName,
					LastName = request.KodlamaUserForRegisterDto.LastName,
					UserName = request.KodlamaUserForRegisterDto.UserName,
					Status = true
				};

				KodlamaUser createdUser = await _kodlamaUserRepository.AddAsync(newUser);

				AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
				RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress);
				RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

				RegisteredDto registeredKodlamaUserDto = new()
				{
					RefreshToken = addedRefreshToken,
					AccessToken = createdAccessToken,
					UserName = createdUser.UserName,
				};
				return registeredKodlamaUserDto;
			}
		}
	}
}
