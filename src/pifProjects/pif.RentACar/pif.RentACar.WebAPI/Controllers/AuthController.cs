using Microsoft.AspNetCore.Mvc;
using pif.Core.Security.Dtos;
using pif.Core.Security.Entities;
using pif.RentACar.Application.Features.Auths.Commands.Register;
using pif.RentACar.Application.Features.Auths.Dtos;

namespace pif.RentACar.WebAPI.Controllers
{

	public class AuthController : BaseController
	{
		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
		{
			RegisterCommand registerCommand = new()
			{
				UserForRegisterDto = userForRegisterDto,
				IpAddress = GetIpAddress()
			};

			RegisteredDto result = await Mediator.Send(registerCommand);
			SetRefreshTokenToCookie(result.RefreshToken);
			return Created("", result.AccessToken);
		}

		private void SetRefreshTokenToCookie(RefreshToken refreshToken)
		{
			CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
			Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
		}

	}
}
