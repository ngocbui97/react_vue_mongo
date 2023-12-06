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
    [Route("api/education")]
    [ApiController]
    public class EducationController : BaseController
    {
        private readonly IEducationService _service;
        public EducationController(IEducationService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EducationParam param)
        {
            ResponseService<EducationModel> response = await _service.Create<EducationModel>(param);
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
        public async Task<IActionResult> Update([FromBody] EducationModel param)
        {
            ResponseService<EducationModel> response = await _service.Update<EducationModel>(param.id, param);
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
            ResponseService<EducationModel> response = await _service.GetById<EducationModel>(param.id);
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
            ResponseService<ListResult<EducationModel>> response = await _service.GetListAsync<EducationModel>(param);
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
