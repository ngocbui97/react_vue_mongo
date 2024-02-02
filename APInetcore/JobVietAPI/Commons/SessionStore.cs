using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using JobVietAPI.Config;

namespace JobVietAPI.Commons
{
    public class SessionStore
    {
        private static IHttpContextAccessor session = ConfigContainerDJ.CreateIntance<IHttpContextAccessor>();
        public static void Set<T>(string key, T data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            if (session != null && session.HttpContext != null && session.HttpContext.Session != null) session.HttpContext.Session.SetString(key, serializedData);
        }
        public static T Get<T>(string key)
        {
            if (session == null || session.HttpContext == null || session.HttpContext.Session == null) return default;
            var data = session.HttpContext.Session.GetString(key);
            if (null != data)
                return JsonConvert.DeserializeObject<T>(data);
            return default(T);
        }
    }
}
