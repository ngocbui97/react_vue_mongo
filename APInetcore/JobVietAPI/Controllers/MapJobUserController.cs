using Microsoft.AspNetCore.Mvc;
using Repository.CustomModels;
using Repository.Params;
using System.Threading.Tasks;
using JobVietAPI.Commons;
using JobVietAPI.CustomAttributes;
using JobVietAPI.Interfaces;
using JobVietAPI.Models;
using JobVietAPI.Params;

namespace JobVietAPI.Controllers
{
    [Route("api/map-job-user")]
    [ApiController]
    public class MapJobUserController : BaseController
    {
        private readonly IMapJobUserService _service;
        public MapJobUserController(IMapJobUserService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] MapJobUserParam param)
        {
            ResponseService<MapJobUserModel> response = await _service.Create<MapJobUserModel>(param);
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
        public async Task<IActionResult> Update([FromBody] MapJobUserModel param)
        {
            ResponseService<MapJobUserModel> response = await _service.Update<MapJobUserModel>(param.id, param);
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
            ResponseService<MapJobUserModel> response = await _service.GetById<MapJobUserModel>(param.id);
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
            ResponseService<ListResult<MapJobUserModel>> response = await _service.GetListAsync<MapJobUserModel>(param);
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
