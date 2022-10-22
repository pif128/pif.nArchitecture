﻿using pif.Core.Security.Entities;
using pif.Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.Kodlama.io.Devs.Application.Services.AuthService
{

	public interface IAuthService
	{
		public Task<AccessToken> CreateAccessToken(User user);
		public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
		public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
	}
}
