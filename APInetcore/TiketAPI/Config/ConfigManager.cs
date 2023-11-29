using Microsoft.Extensions.Configuration;
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
