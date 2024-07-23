using Microsoft.OpenApi.Models;

namespace Test.Quiz.Api.Providers
{
    public static class AppProvider
    {
        public static IServiceCollection AddAppProvider(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddHttpClient();

            return services;
        }
    }
}
