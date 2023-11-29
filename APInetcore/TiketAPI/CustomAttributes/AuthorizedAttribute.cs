using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Repository.Repository;
using System;
using System.Threading.Tasks;
using TiketAPI.Commons;
using TiketAPI.Extensions;
using TiketAPI.Models;
using TiketAPI.Services;
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
        private async Task<bool> Authorize(HttpContext actionContext)
        {
            try
            {
                var header = actionContext.Request.Headers;

                //if session timeout
                string token = actionContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

                // validate token
                if (this.authorDefault == AUTHOR.TOKEN)
                {
                    if (CommonFunc.DecodeToken(token) != null) return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
