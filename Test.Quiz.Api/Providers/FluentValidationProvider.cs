using FluentValidation.AspNetCore;
using System.Reflection;

namespace Test.Quiz.Api.Providers
{
    public static class FluentValidationProvider
    {
        public static IServiceCollection AddFluentValidationProvider(this IServiceCollection services)
        {
            services.AddFluentValidation(options =>
            {
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;

                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
