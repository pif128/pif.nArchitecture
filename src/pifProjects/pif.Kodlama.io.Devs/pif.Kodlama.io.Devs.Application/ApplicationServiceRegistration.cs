using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using pif.Core.Application.Pipelines.Authorization;
using pif.Core.Application.Pipelines.Logging;
using pif.Core.Application.Pipelines.Validation;
using pif.Kodlama.io.Devs.Application.Features.Auths.Rules;
using pif.Kodlama.io.Devs.Application.Features.GithubProfiles.Rules;
using pif.Kodlama.io.Devs.Application.Features.KodlamaUserOperationClaims.Rules;
using pif.Kodlama.io.Devs.Application.Features.OperationClaims.Rules;
using pif.Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using pif.Kodlama.io.Devs.Application.Features.Technologies.Rules;
using pif.Kodlama.io.Devs.Application.Services.AuthService;
using System.Reflection;

namespace pif.Kodlama.io.Devs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<TechnologyBusinessRules>();
            services.AddScoped<GithubProfileBusinessRule>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<KodlamaUserOperationClaimBusinessRule>();
            services.AddScoped<OperationClaimBusinessRule>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

			services.AddScoped<IAuthService, AuthManager>();


			return services;

        }
    }
}