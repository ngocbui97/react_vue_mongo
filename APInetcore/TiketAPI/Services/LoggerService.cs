using Newtonsoft.Json;
using NLog;
using System;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class LoggerService : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }
        public void LogError(Exception ex)
        {
            logger.Error(JsonConvert.SerializeObject(ex));
        }
        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
