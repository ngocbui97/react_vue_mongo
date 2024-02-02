using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;
using JobVietAPI.Commons;

namespace JobVietAPI.Extensions
{
    public static class AuthenticationExtension
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration config)
        {
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

                 //options.Events = new JwtBearerEvents
                 //{
                 //    OnMessageReceived = context =>
                 //    {
                 //        var path = context.HttpContext.Request.Path;
                 //        if (path.StartsWithSegments("/steamHup"))
                 //        {
                 //            // Attempt to get a token from a query sting used by WebSocket
                 //            var accessToken = context.Request.Query["access_token"];
                 //            // If not present, extract the token from Authorization header
                 //            if (string.IsNullOrWhiteSpace(accessToken))
                 //            {
                 //                accessToken = context.Request.Headers["Authorization"]
                 //                    .ToString()
                 //                    .Replace("Bearer ", "");
                 //            }
                 //            context.Token = accessToken;
                 //        }
                 //        return Task.CompletedTask;
                 //    }
                 //};


             });
             return services;
        }
    }
}
