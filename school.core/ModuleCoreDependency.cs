using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using school.core.NewFolder;
using System.Reflection;

namespace school.core
{
    public static class ModuleCoreDependency
    {
        public static IServiceCollection addCoredependecies(this IServiceCollection services)
        {
            // AddMediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            // Get AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // IPipelineBehavior ... ValidationBehavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
