using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pif.RentACar.Application.Services.Repositories;
using pif.RentACar.Pesistence.Contexts;
using pif.RentACar.Pesistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pif.RentACar.Pesistence
{

	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
																IConfiguration configuration)
		{
			services.AddDbContext<BaseDbContext>(options =>
													 options.UseSqlServer(
														 configuration.GetConnectionString("RentACarCampConnectionString")));
			services.AddScoped<IBrandRepository, BrandRepository>();
			services.AddScoped<IModelRepository, ModelRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
			services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
			services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

			return services;
		}
	}
}
