using Microsoft.Extensions.DependencyInjection;
using System;

namespace TiketAPI.Config
{
    public class ConfigContainerDJ
    {
        public static IServiceProvider CurrentProvider { get; internal set; }

        public static T CreateIntance<T>()
        {
            return CurrentProvider.GetService<T>();
        }
    }
}
