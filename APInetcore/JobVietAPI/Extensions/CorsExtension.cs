using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobVietAPI.Extensions
{
    public static class CorsExtension
    {
        public static void ConfigureCors(this IApplicationBuilder app, IConfiguration config)
        {
            var configValue = config.GetSection("AllowedHosts").Value;
            string[] CORSComplianceDomains = configValue.Split(",");

            if(configValue == "*")
            {
               app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) 
                .AllowCredentials()); 
            }
            else
            {
                app.UseCors(x => x
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .WithOrigins(CORSComplianceDomains)
                 .AllowCredentials());
            }
        }
    }
}
