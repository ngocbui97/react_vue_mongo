using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketAPI.Interfaces;

namespace TiketAPI.Config
{
    public class ConfigManager : IConfigManager
    {
        public IConfiguration Configuration { get; }
        public ConfigManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string Get(string nameConfig)
        {
            return null;
        }
    }
}
