using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using Repository.Interface;
using Repository.Repository;
using TiketAPI.Commons;
using TiketAPI.CustomAttributes;
using TiketAPI.Extensions;
using TiketAPI.Interfaces;
using TiketAPI.Services;

namespace TiketAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(Startup));

            services.AddCustomSwagger();
            services.AddMemoryCache();
            services.ConfigureLoggerService();
            services.AddControllers();
            services.AddTokenAuthentication(Configuration);
            services.ConfigureCors();
            services.AddScoped<ModelValidationAttribute>();
            services.AddSingleton<ILoggerManager, LoggerService>();

            // Inject repository
            services.AddSingleton<IUserRepositoty, UserRepository>();
            services.AddSingleton<IProfileRepository, ProfileRepository>();

            // Inject service
            services.AddSingleton<IUserService, UserService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.ConfigureExceptionHandler(logger);

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCustomSwagger();
           
        }
    }
}
