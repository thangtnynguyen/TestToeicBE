using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Test.Quiz.Api.Data.EntityFrameworkCore;
using Test.Quiz.Api.Data.Entities;

namespace Test.Quiz.Api.Providers
{
    public static class IdentityProvider
    {
        public static IServiceCollection AddIdentityProvider(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddIdentity<User, Data.Entities.Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.AllowedUserNameCharacters = null;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            var jwtKey = builder.Configuration.GetValue<string>("Jwt:Key");

            var key = Encoding.ASCII.GetBytes(jwtKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //var permissionType = typeof(Constants.Permission);
            //var permissionFields = permissionType.GetFields(BindingFlags.Public | BindingFlags.Static)
            //.Where(f => f.IsLiteral && !f.IsInitOnly)
            //.Select(f => (string)f.GetValue(null))
            //.ToList();

            //services.AddAuthorization(options =>
            //{
            //    foreach (var permission in permissionFields)
            //    {
            //        options.AddPolicy(permission, policy =>
            //        {
            //            policy.RequireClaim("Permission", permission);
            //        });
            //    }
            //});

            return services;
        }
    }
}
