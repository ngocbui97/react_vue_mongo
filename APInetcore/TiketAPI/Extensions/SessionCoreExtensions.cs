using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TiketAPI.Extensions
{
    public static class SessionCoreExtensions
    {
        public static void Add<T>(this ISession iSession, string key, T data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            iSession.SetString(key, serializedData);
        }
        public static T Get<T>(this ISession iSession, string key)
        {
            var data = iSession.GetString(key);
            if (null != data)
                return JsonConvert.DeserializeObject<T>(data);
            return default(T);
        }
    }
}
