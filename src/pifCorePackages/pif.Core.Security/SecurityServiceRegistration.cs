using pif.Core.Security.EmailAuthenticator;
using pif.Core.Security.JWT;
using pif.Core.Security.OtpAuthenticator;
using pif.Core.Security.OtpAuthenticator.OtpNet;
using Microsoft.Extensions.DependencyInjection;

namespace pif.Core.Application
{

	public static class SecurityServiceRegistration
	{
		public static IServiceCollection AddSecurityServices(this IServiceCollection services)
		{
			services.AddScoped<ITokenHelper, JwtHelper>();
			services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
			services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
			return services;
		}
	}
}