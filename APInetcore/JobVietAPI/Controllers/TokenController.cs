﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using JobVietAPI.Services;

namespace JobVietAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : BaseController
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public string GetRandomToken()
        {
            var jwt = new JwtService(_config);
            var token = jwt.GenerateSecurityToken("fake@email.com", false);
            return token;
        }
    }
}
