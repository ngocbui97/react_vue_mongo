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
    [Route("api/conversation")]
    [ApiController]
    public class ConversationController : BaseController
    {
        private readonly IConversationService _service;
        public ConversationController(IConversationService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ConversationParam param)
        {
            ResponseService<ConversationModel> response = await _service.Create<ConversationModel>(param);
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
        public async Task<IActionResult> Update([FromBody] ConversationModel param)
        {
            ResponseService<ConversationModel> response = await _service.Update<ConversationModel>(param.id, param);
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
            ResponseService<ConversationModel> response = await _service.GetById<ConversationModel>(param.id);
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
            ResponseService<ListResult<ConversationModel>> response = await _service.GetListAsync<ConversationModel>(param);
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
