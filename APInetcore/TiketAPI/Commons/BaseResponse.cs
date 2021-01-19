using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TiketAPI.Commons
{
    public class BaseResponse<T>
    {
        public HttpStatusCode statusCode { get; set; }
        public string status { get; set; }
        public string mess { get; set; }

        public T data { get; set; }

        public bool success { get; set; }

    }
}
