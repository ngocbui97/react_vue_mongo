using Microsoft.Extensions.DependencyInjection;
using JobVietAPI.Interfaces;
using JobVietAPI.Services;

namespace JobVietAPI.Extensions
{
    public static class LoggerExtention
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerService>();
        }
    }
}
