using Microsoft.AspNetCore.Mvc;
using Repository.CustomModels;
using Repository.EF;
using Repository.Params;
using System.Threading.Tasks;
using TiketAPI.Commons;
using TiketAPI.CustomAttributes;
using TiketAPI.Interfaces;
using TiketAPI.Models;
using TiketAPI.Params;

namespace TiketAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _service;
        public UserController(IUserService userService)
        {
            _service = userService;
        }

        [Authorized]
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UserModel param)
        {
            ResponseService<UserModel> response = await _service.Update<UserModel>(param.id, param);
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
            ResponseService<UserModel> response = await _service.GetById<UserModel>(param.id);
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
            ResponseService<bool> response = await _service.Delete(param.id);
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
        [HttpPost("get-list")]
        public async Task<IActionResult> GetList([FromBody] PagingParam param)
        {
            ResponseService<ListResult<UserModel>> response = (await _service.GetListAsync(param))
                .ConvertToResponse<User, UserModel>();
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserParam param)
        {
            ResponseService<UserModel> response = await _service.Register(param);
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
            ResponseService<ListResult<UserInfo>> response = await _service.GetUsersInfo(param);
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginParam param)
        {
            ResponseService<ResponseLoginModel> response = await _service.Login(param.email, param.password);
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
            ResponseService<bool> response = await _service.ForgotPassword(param.email);
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
            ResponseService<bool> response = await _service.ResetPassword(param.code,param.email, param.password);
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
