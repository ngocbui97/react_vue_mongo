using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketAPI.Extensions
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors();
            services.AddControllers();

            var secret = config.GetSection("JwtConfig").GetSection("secret").Value;

            var key = Encoding.ASCII.GetBytes(secret);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false
                 };
             });

            return services;
        }
    }
}
