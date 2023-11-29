using Microsoft.Extensions.DependencyInjection;
using TiketAPI.Interfaces;
using TiketAPI.Services;

namespace TiketAPI.Extensions
{
    public static class LoggerExtention
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerService>();
        }
    }
}
