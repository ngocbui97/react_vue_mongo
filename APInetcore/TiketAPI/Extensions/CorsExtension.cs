﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketAPI.Extensions
{
    public static class CorsExtension
    {
        public static void ConfigureCors(this IServiceCollection services, IConfiguration config)
        {
            var configValue = config.GetSection("CORSComplianceDomains").Value;
            string[] CORSComplianceDomains = configValue.Split("|,|");

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {

                        builder.WithOrigins("http://localhost:3000");
                    });

                options.AddPolicy("AnotherPolicy",
                    builder =>
                    {
                        builder.WithOrigins(CORSComplianceDomains)
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });

            });
        }
    }
}
