using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
