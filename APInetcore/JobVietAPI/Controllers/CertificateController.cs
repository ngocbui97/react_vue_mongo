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
    [Route("api/certificate")]
    [ApiController]
    public class CertificateController : BaseController
    {
        private readonly ICertificateService _service;
        public CertificateController(ICertificateService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CertificateParam param)
        {
            ResponseService<CertificateModel> response = await _service.Create<CertificateModel>(param);
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
        public async Task<IActionResult> Update([FromBody] CertificateModel param)
        {
            ResponseService<CertificateModel> response = await _service.Update<CertificateModel>(param.id, param);
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
            ResponseService<CertificateModel> response = await _service.GetById<CertificateModel>(param.id);
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
            ResponseService<ListResult<CertificateModel>> response = await _service.GetListAsync<CertificateModel>(param);
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
