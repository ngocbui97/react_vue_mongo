using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.EF;
using Repository.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiketAPI.Commons;
using TiketAPI.CustomAttributes;
using TiketAPI.Extensions;
using TiketAPI.Interfaces;
using TiketAPI.Models;

namespace TiketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel user)
        {
            ResponseService<User> response = await _userService.Register(user);
            if (!response.Success) return BadRequest(response.Message);
            return Ok(response.Resource);
        }
        //[HttpPost("logout")]
        //public async Task<IActionResult> Logout()
        //{
           
        //}
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel user)
        {
            ResponseService<UserLoginModel> response = await _userService.Login(user.Email, user.Password);
            if (response.Success)
            {
                HttpContext.Session.Add<UserLoginModel>(Constants.SESSION_LOGIN, response.Resource); 
                return Ok(response.Resource);
            }
            else 
            {
                return BadRequest(response.Message);
            } 
           
        }

        [Permission(Name = "view")]
        [HttpGet("list-user")]
        public async Task<IActionResult> GetList([FromBody] UserModel user)
        {
            QueryParram queryParram = new QueryParram(1, 2);
            ResponseService <QueryListResult<User>> response = await _userService.GetListAsync(queryParram);
            if (response.Success)
            {
                return Ok(response.Resource);
            }
            else
            {
                return BadRequest(response.Message);
            }

        }

        protected bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
