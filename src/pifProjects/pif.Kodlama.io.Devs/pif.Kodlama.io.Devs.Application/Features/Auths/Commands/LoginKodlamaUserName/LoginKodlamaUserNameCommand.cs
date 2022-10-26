using MediatR;
using Microsoft.EntityFrameworkCore;
using pif.Core.Security.Entities;
using pif.Core.Security.Hashing;
using pif.Core.Security.JWT;
using pif.Kodlama.io.Devs.Application.Features.Auths.Dtos;
using pif.Kodlama.io.Devs.Application.Features.Auths.Rules;
using pif.Kodlama.io.Devs.Application.Services.AuthService;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;

namespace pif.Kodlama.io.Devs.Application.Features.Auths.Commands.LoginKodlamaUserName
{
	public class LoginKodlamaUserNameCommand : IRequest<LoginnedDto>
	{
		public KodlamaUserForLoginUserNameDto KodlamaUserForLoginUserNameDto { get; set; }
		public string IpAddress { get; set; }
		public class LoginKodlamaUserNameCommandHandler : IRequestHandler<LoginKodlamaUserNameCommand, LoginnedDto>
		{

			private readonly IKodlamaUserRepository _kodlamaUserRepository;
			private readonly IAuthService _authService;
			private readonly AuthBusinessRules _authBusinessRules;

			public LoginKodlamaUserNameCommandHandler(IKodlamaUserRepository kodlamaUserRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
			{
				_kodlamaUserRepository = kodlamaUserRepository;
				_authService = authService;
				_authBusinessRules = authBusinessRules;
			}

			async Task<LoginnedDto> IRequestHandler<LoginKodlamaUserNameCommand, LoginnedDto>.Handle(LoginKodlamaUserNameCommand request, CancellationToken cancellationToken)
			{

				KodlamaUser kodlamaUser = await _kodlamaUserRepository.GetAsync(x => x.UserName == request.KodlamaUserForLoginUserNameDto.UserName,
					include: x => x.Include(c => c.UserOperationClaims));
				await _authBusinessRules.CheckKodlamaUserWhenLogin(kodlamaUser);

				var verifyPassword = HashingHelper.VerifyPasswordHash(request.KodlamaUserForLoginUserNameDto.Password, kodlamaUser.PasswordHash, kodlamaUser.PasswordSalt);
				await _authBusinessRules.CheckKodlamaUserPasswordWhenLogin(verifyPassword);


				AccessToken createdAccessToken = await _authService.CreateAccessToken(kodlamaUser);
				RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(kodlamaUser, request.IpAddress);
				RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

				LoginnedDto loginnedDto = new()
				{
					RefreshToken = addedRefreshToken,
					AccessToken = createdAccessToken,
				};
				return loginnedDto;
			}
		}
	}
}
