using System.Net;
using System;

namespace TiketAPI.Commons
{
    public class ResponseService<T>
    {
        public bool success { get; private set; }
        public string message { get; private set; }
        public T data { get; private set; }
        public Exception exception { get; set; }
        public HttpStatusCode status_code { get; set; }

        public ResponseService(T data)
        {
            this.success = true;
            this.message = string.Empty;
            this.data = data;
            this.status_code = HttpStatusCode.OK;
        }

        public ResponseService(string message)
        {
            this.success = false;
            this.message = message;
            this.data = default;
        }
        public ResponseService(Exception ex)
        {
            this.success = false;
            this.message = ex.Message;
            this.data = default;
            this.exception = ex;
            this.status_code = HttpStatusCode.InternalServerError;
        }
        public ResponseService<T> BadRequest(int errorCode = -1)
        {
            this.status_code = HttpStatusCode.BadRequest;
            this.success = false;
            return this;
        }
        public ResponseService<T> Unauthorized()
        {
            this.status_code = HttpStatusCode.Unauthorized;
            this.success = false;
            return this;
        }
    }
}
