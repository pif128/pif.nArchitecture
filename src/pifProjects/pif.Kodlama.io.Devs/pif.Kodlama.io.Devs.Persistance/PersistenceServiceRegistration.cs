using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pif.Kodlama.io.Devs.Application.Services.Repositories;
using pif.Kodlama.io.Devs.Persistance.Contexts;
using pif.Kodlama.io.Devs.Persistance.Repositories;

namespace pif.Kodlama.io.Devs.Persistance
{

	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
																IConfiguration configuration)
		{
			services.AddDbContext<BaseDbContext>(options =>
													 options.UseSqlServer(
														 configuration.GetConnectionString("OdevDay3ConnectionString")));
			services.AddScoped<IProgrammingLanguageRepository, ProgrammingLanguageRepository>();
			services.AddScoped<ITechnologyRepository, TechnologyRepository>();
			services.AddScoped<IGithubProfileRepository, GithubProfileRepository>();
			services.AddScoped<IKodlamaUserRepository, KodlamaUserRepository>();
			services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
			services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
			services.AddScoped<IKodlamaUserOperationClaimRepository, KodlamaUserOperationClaimRepository>();

			return services;
		}
	}
}