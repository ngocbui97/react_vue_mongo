using Microsoft.AspNetCore.Mvc;
using Repository.CustomModels;
using Repository.EF;
using Repository.Params;
using System.Threading.Tasks;
using TiketAPI.Commons;
using TiketAPI.CustomAttributes;
using TiketAPI.Interfaces;
using TiketAPI.Models;

namespace TiketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskJobController : BaseController
    {
        private readonly IUserService _userService;
        public TaskJobController(IUserService userService)
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
            ResponseService<ListResult<UserModel>> response = (await _userService.GetListAsync(param)).ConvertTo<User, UserModel>();
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

    }
}
