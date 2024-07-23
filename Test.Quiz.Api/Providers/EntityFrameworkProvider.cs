using Microsoft.EntityFrameworkCore;
using Test.Quiz.Api.Data.EntityFrameworkCore;

namespace Test.Quiz.Api.Providers
{
    public static class EntityFrameworkProvider
    {
        public static IServiceCollection AddEntityFrameworkProvider(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient);

            return services;
        }
    }
}
