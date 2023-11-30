using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.CustomModels;
using Repository.EF;
using Repository.Params;
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

        [Authorized]
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] User param)
        {
            ResponseService<User> response = await _userService.Update(param.id, param);
            if (response.success) 
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [Authorized]
        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById([FromBody] ItemParam param)
        {
            ResponseService<User> response = await _userService.GetById(param.id);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [Authorized]
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] ItemParam param)
        {
            ResponseService<bool> response = await _userService.Delete(param.id);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [Authorized]
        [HttpPost("list-user")]
        public async Task<IActionResult> GetList([FromBody] PagingParam param)
        {
            ResponseService <ListResult<User>> response = await _userService.GetListAsync(param);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [Authorized]
        [HttpPost("list-user-info")]
        public async Task<IActionResult> GetUserInfo([FromBody] SearchUserParam param)
        {
            ResponseService<ListResult<UserInfo>> response = await _userService.GetUsersInfo(param);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel param)
        {
            ResponseService<User> response = await _userService.Register(param);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginParam param)
        {
            ResponseService<ResponseLoginModel> response = await _userService.Login(param.email, param.password);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] EmailParam param)
        {
            ResponseService<bool> response = await _userService.ForgotPassword(param.email);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassParam param)
        {
            ResponseService<bool> response = await _userService.ResetPassword(param.code,param.email, param.password);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
