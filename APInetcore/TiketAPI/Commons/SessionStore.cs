using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketAPI.Commons
{
    public class SessionStore
    {
        public static string Get(string key)
        {
            //if (HttpContext.Current.Session[key] != null)
            //{
            //    return HttpContext.Current.Session[key].ToString();
            //}
            return null;
        }
        public static void Set(string key, string value)
        {
            //HttpContext.Current.Session[key] = value;
        }
    }
}
