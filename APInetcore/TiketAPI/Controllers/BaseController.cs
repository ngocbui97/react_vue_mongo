using Microsoft.AspNetCore.Mvc;
using TiketAPI.Models;

namespace TiketAPI.Controllers
{
    public class BaseController : ControllerBase
    {
       public RequestModel<T> ToRequestModel<T>(T data)
        {
            return new RequestModel<T> { data = data };
        }
    }
}
