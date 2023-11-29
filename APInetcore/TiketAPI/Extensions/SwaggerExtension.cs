using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TiketAPI.Config;

namespace TiketAPI.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Ticket API", Version = "v1" });
                c.OperationFilter<AuthorizationOperationFiltercs>();
                c.SchemaFilter<SchemaFilter>();
            });
            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket API");
                options.DocumentTitle = "Ticket API";
            });
            return app;
        }
    }
}
