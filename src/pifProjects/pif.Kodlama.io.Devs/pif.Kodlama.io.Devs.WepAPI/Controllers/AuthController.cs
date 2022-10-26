using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pif.Core.Security.Dtos;
using pif.Core.Security.Entities;
using pif.Kodlama.io.Devs.Application.Features.Auths.Commands.LoginKodlamaUserName;
using pif.Kodlama.io.Devs.Application.Features.Auths.Commands.RegisterKodlamaUser;
using pif.Kodlama.io.Devs.Application.Features.Auths.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Security.Claims;
using System.Text;

namespace pif.Kodlama.io.Devs.WepAPI.Controllers
{
	public class AuthController : BaseController
	{
		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] KodlamaUserForRegisterDto kodlamaUserForRegisterDto)
		{
			RegisterKodlamaUserCommand registerKodlamaUserCommand = new()
			{
				KodlamaUserForRegisterDto = kodlamaUserForRegisterDto,
				IpAddress = GetIpAddress()
			};

			RegisteredDto result = await Mediator.Send(registerKodlamaUserCommand);
			SetRefreshTokenToCookie(result.RefreshToken);
			return Created("", result.AccessToken);
		}


		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] KodlamaUserForLoginUserNameDto kodlamaUserForLoginUserNameDto)
		{
			LoginKodlamaUserNameCommand loginKodlamaUserNameCommand = new()
			{
				KodlamaUserForLoginUserNameDto = kodlamaUserForLoginUserNameDto,
				IpAddress = GetIpAddress()
			};

			LoginnedDto result = await Mediator.Send(loginKodlamaUserNameCommand);

			SetRefreshTokenToCookie(result.RefreshToken);
			return Ok( result.AccessToken);
		}

		private void SetRefreshTokenToCookie(RefreshToken refreshToken)
		{
			CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
			Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
		}





	}
}
