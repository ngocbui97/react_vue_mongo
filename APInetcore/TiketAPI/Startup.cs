using System;
using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using Repository.CustomContext;
using Repository.Interface;
using Repository.Repository;
using TiketAPI.Commons;
using TiketAPI.Config;
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
            services.AddDbContext<DbContextCustom>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient);

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
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.ConfigureLoggerService();
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddTokenAuthentication(Configuration);
            services.ConfigureCors(Configuration);
            services.AddScoped<ModelValidationAttribute>();
            services.AddSingleton<ILoggerManager, LoggerService>();
            services.AddAuthorization(options =>
            {
                //options.AddPolicy("Permission", policyBuilder =>
                //{
                //    policyBuilder.Requirements.Add(new PermissionAuthorizationRequirement());
                //});
            });

            // Inject repository
            services.AddSingleton(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ISkillRepository, SkillRepository>();

            // Inject service
            services.AddSingleton<IUserService, UserService>();

            // store service provider
            ConfigContainerDJ.CurrentProvider = services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.ConfigureExceptionHandler(logger);

            app.UseCors("AnotherPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCustomSwagger();
           
        }
    }
}
