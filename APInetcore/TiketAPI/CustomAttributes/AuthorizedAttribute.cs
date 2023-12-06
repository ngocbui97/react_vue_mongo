using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using TiketAPI.Commons;
using static TiketAPI.Constants;

namespace TiketAPI.CustomAttributes
{
    public class AuthorizedAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private AUTHOR authorDefault = AUTHOR.TOKEN;

        public AuthorizedAttribute()
        {
            this.authorDefault = AUTHOR.TOKEN;
        }

        public AuthorizedAttribute(AUTHOR authorType)
        {
            this.authorDefault = authorType;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!await Authorize(context.HttpContext)) context.Result = new UnauthorizedResult();
            return;
        }
        private Task<bool> Authorize(HttpContext actionContext)
        {
            try
            {
                var header = actionContext.Request.Headers;

                //if session timeout
                string token = actionContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

                // validate token
                if (this.authorDefault == AUTHOR.TOKEN)
                {
                    if (CommonFunc.DecodeToken(token) != null) return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
