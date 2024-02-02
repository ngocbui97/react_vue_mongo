using Microsoft.Extensions.Configuration;
using JobVietAPI.Interfaces;

namespace JobVietAPI.Config
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
