using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TiketAPI.Config;

namespace TiketAPI.Commons
{
    public class SessionStore
    {
        private static ISession session = ConfigContainerDJ.CreateIntance<ISession>();
        public static void Set<T>(string key, T data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            if (session != null) session.SetString(key, serializedData);
        }
        public static T Get<T>(string key)
        {
            if (session == null) return default;
            var data = session.GetString(key);
            if (null != data)
                return JsonConvert.DeserializeObject<T>(data);
            return default(T);
        }
    }
}
