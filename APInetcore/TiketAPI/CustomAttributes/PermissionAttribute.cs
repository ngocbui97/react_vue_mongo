using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketAPI.Extensions;
using TiketAPI.Interfaces;
using TiketAPI.Models;
using TiketAPI.Services;

namespace TiketAPI.CustomAttributes
{
    public class PermissionAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public string Name { get; set; }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            UserLoginModel userLogin = context.HttpContext.Session.Get<UserLoginModel>(Constants.SESSION_LOGIN);
            if (userLogin == null)
            {
                context.Result = new ForbidResult();
                return;
            }
            UserRepository userRepository = new UserRepository();
            Boolean isAuthor = await userRepository.CheckPermission(userLogin.Id, Name);
            if (!isAuthor) context.Result = new ForbidResult();
            return;
        }
    }
}
