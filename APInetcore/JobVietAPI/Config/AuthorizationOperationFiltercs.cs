using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace JobVietAPI.Config
{
    public class AuthorizationOperationFiltercs : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();

            }

            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "apiKey",
                In = ParameterLocation.Header,
                Required = false
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Description = "access token",
                Required = false,
                Schema = new OpenApiSchema() { Type = "String", Default = new OpenApiString("Bearer ") },
            }); ;
        }
    }
}
