using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace TiketAPI.Config
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
                Name = "SecretKey",
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
    public class SchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            var ignoreDataMemberProperties = context.Type.GetProperties()
                .Where(t => t.GetCustomAttribute<IgnoreDataMemberAttribute>() != null);

            foreach (var ignoreDataMemberProperty in ignoreDataMemberProperties)
            {
                var propertyToHide = schema.Properties.Keys
                    .SingleOrDefault(x => x.ToLower() == ignoreDataMemberProperty.Name.ToLower());

                if (propertyToHide != null)
                {
                    schema.Properties.Remove(propertyToHide);
                }
            }
        }
    }
}
