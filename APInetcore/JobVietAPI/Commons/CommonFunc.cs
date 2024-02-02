using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using JobVietAPI.Extensions;

namespace JobVietAPI.Commons
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

            var a = SessionStore.Get<string>(Constants.KEY_SESSION_EMAIL);
            SessionStore.Set<string>(Constants.KEY_SESSION_EMAIL, emailClaim.Value);

            if (emailClaim != null) return emailClaim.Value;
            return null;
        }
        public static T SetValue<T>(T obj, string propertyName, object ? value)
        {
            try
            {
                // these should be cached if possible
                Type type = obj.GetType();
                PropertyInfo pi = type.GetProperty(propertyName);

                if (pi == null) return obj;

                Type t = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;

                object safeValue = (value == null) ? null : Convert.ChangeType(value, t);

                pi.SetValue(obj, safeValue, null);

                return obj;
            }
            catch(Exception ex) { }

            return obj;
        }
        public static T UpdateInfo<T>(T value, bool isNewInfo = true)
        {
            string by = SessionStore.Get<string>(Constants.KEY_SESSION_EMAIL);

            if (isNewInfo)
            {
                value = SetValue(value, "id", Guid.NewGuid());
                value = SetValue(value, "create_time", DateTime.Now);
                value = SetValue(value, "create_by", by);
            }

            value = SetValue(value, "modify_time", DateTime.Now);
            value = SetValue(value, "modify_by", by);

            return (T)value;
        }
    }
}
