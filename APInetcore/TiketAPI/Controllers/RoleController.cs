using Microsoft.AspNetCore.Mvc;
using Repository.CustomModels;
using Repository.Params;
using System.Threading.Tasks;
using TiketAPI.Commons;
using TiketAPI.CustomAttributes;
using TiketAPI.Interfaces;
using TiketAPI.Models;
using TiketAPI.Params;

namespace TiketAPI.Controllers
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RoleParam param)
        {
            ResponseService<RoleModel> response = await _service.Create<RoleModel>(param);
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
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] RoleModel param)
        {
            ResponseService<RoleModel> response = await _service.Update<RoleModel>(param.id, param);
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
            ResponseService<RoleModel> response = await _service.GetById<RoleModel>(param.id);
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
            ResponseService<ListResult<RoleModel>> response = await _service.GetListAsync<RoleModel>(param);
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
