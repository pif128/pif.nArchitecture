using Microsoft.EntityFrameworkCore;
using pif.Core.Persistence.Paging;
using pif.Core.Security.Entities;
using pif.Core.Security.JWT;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Services.AuthService
{

	public class AuthManager : IAuthService
	{
		private readonly IKodlamaUserOperationClaimRepository _userOperationClaimRepository;
		private readonly ITokenHelper _tokenHelper;
		private readonly IRefreshTokenRepository _refreshTokenRepository;

		public AuthManager(IKodlamaUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository)
		{
			_userOperationClaimRepository = userOperationClaimRepository;
			_tokenHelper = tokenHelper;
			_refreshTokenRepository = refreshTokenRepository;
		}

		public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
		{
			RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
			return addedRefreshToken;
		}

		public async Task<AccessToken> CreateAccessToken(User user)
		{
			IPaginate<KodlamaUserOperationClaim> userOperationClaims =
			   await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
																include: u =>
																	u.Include(u => u.OperationClaim)
			   );
			IList<OperationClaim> operationClaims =
				userOperationClaims.Items.Select(u => new OperationClaim
				{ Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();

			AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
			return accessToken;
		}

		public async Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
		{
			RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
			return await Task.FromResult(refreshToken);
		}
	}
}
