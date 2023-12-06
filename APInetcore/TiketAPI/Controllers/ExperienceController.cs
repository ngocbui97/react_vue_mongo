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
    [Route("api/experience")]
    [ApiController]
    public class ExperienceController : BaseController
    {
        private readonly IExperienceService _service;
        public ExperienceController(IExperienceService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ExperienceParam param)
        {
            ResponseService<ExperienceModel> response = await _service.Create<ExperienceModel>(param);
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
        public async Task<IActionResult> Update([FromBody] ExperienceModel param)
        {
            ResponseService<ExperienceModel> response = await _service.Update<ExperienceModel>(param.id, param);
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
            ResponseService<ExperienceModel> response = await _service.GetById<ExperienceModel>(param.id);
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
            ResponseService<ListResult<ExperienceModel>> response = await _service.GetListAsync<ExperienceModel>(param);
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
