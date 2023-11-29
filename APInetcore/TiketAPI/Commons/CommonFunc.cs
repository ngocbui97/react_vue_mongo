using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;

namespace TiketAPI.Commons
{
    public class CommonFunc
    {
        public static string GetMethodName(StackTrace stackTrace)
        {
            var method = stackTrace.GetFrame(0).GetMethod();

            string _methodName = method.DeclaringType.FullName;

            if (_methodName.Contains(">") || _methodName.Contains("<"))
            {
                _methodName = _methodName.Split('<', '>')[1];
            }
            else
            {
                _methodName = method.Name;
            }

            return _methodName;
        }
        public static bool ValidateToken(string token)
        {
            return false;
        }
        public static string DecodeToken(string token)
        {
            JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = _tokenHandler.ReadJwtToken(token);

            var emailClaim = jwtSecurityToken.Claims.First(claim => claim.Type == "email");
            if (emailClaim != null) return emailClaim.Value;
            return null;
        }
        public static Object SetValue<T>(T obj, string propertyName, object ? value)
        {
            try
            {
                // these should be cached if possible
                Type type = obj.GetType();
                PropertyInfo pi = type.GetProperty(propertyName);

                Type t = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;

                object safeValue = (value == null) ? null : Convert.ChangeType(value, t);

                pi.SetValue(obj, safeValue, null);

                return obj;
            }
            catch(Exception ex) { }

            return obj;
        }
        public static T AddInfo<T>(Object value, string by = null)
        {
            value = SetValue(value, "id", Guid.NewGuid());
            value = SetValue(value, "create_time", DateTime.Now);
            value = SetValue(value, "modify_time", DateTime.Now);
            value = SetValue(value, "create_by", by);
            value = SetValue(value, "modify_by", by);

            return (T)value;
        }
    }
}
