using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace JobVietAPI.Commons
{
    public class ResponseFail<T> : IActionResult
    {
        private HttpStatusCode statusCode { get; set; }
        private string message { get; set; }
        private Exception exception { get; set; }
        private ResponseService<T> resService { get; set; }
        public ResponseFail() { }

        public ResponseFail(HttpStatusCode statusCode, string errorMessage) : this(statusCode, errorMessage, null)
        { }

        public ResponseFail(HttpStatusCode statusCode, string errorMessage, Exception exception)
        {
            this.statusCode = statusCode;
            this.message = errorMessage;
            this.exception = exception;
        }
        public ResponseFail<T> Error(ResponseService<T> resService)
        {
            this.statusCode = HttpStatusCode.InternalServerError;
            this.message = resService.message;
            this.resService = resService;
            return this;
        }
        public ResponseFail<T> BadRequest(ResponseService<T> resService)
        {
            this.statusCode = HttpStatusCode.BadRequest;
            this.message = resService.message;
            this.resService = resService;
            return this;
        }
        public ResponseFail<T> Unauthorized(ResponseService<T> resService)
        {
            this.statusCode = HttpStatusCode.Unauthorized;
            this.message = resService.message;
            this.resService = resService;
            return this;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(statusCode);
            StringBuilder stringBldr = new StringBuilder();
            response.Content = new StringContent(JsonConvert.SerializeObject(resService), Encoding.UTF8, "application/json");
            return Task.FromResult(response);
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(resService), Encoding.UTF8);
            return Task.FromResult(context);
        }
    }
}
