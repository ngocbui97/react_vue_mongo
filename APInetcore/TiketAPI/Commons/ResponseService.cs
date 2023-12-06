using System.Net;
using System;
using Repository.CustomModels;
using AutoMapper;
using TiketAPI.Config;
using TiketAPI.Interfaces;
using System.Collections.Generic;

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
   
    public static class ResponseServiceExtension
    {
        private static readonly IMapper _mapper = ConfigContainerDJ.CreateIntance<IMapper>();
        private static ILoggerManager _logger = ConfigContainerDJ.CreateIntance<ILoggerManager>();

        /// <summary>
        /// convert response type T to V
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static ResponseService<V> ConvertToResponse<T,V>(this ResponseService<T> response)
        {
            try
            {
                if (response.success)
                {
                    V view = _mapper.Map<T,V>(response.data);
                    return new ResponseService<V>(view);
                }
                else
                {
                    return new ResponseService<V>(response.message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<V>(ex.Message);
            }
        }

        /// <summary>
        /// convert response list result type T to V
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public static ResponseService<ListResult<V>> ConvertToResponse<T, V>(this ResponseService<ListResult<T>> response)
        {
            try
            {
                if (response.success)
                {
                    List<V> view = _mapper.Map<List<T>,List<V>>(response.data.items);
                    return new ResponseService<ListResult<V>>(new ListResult<V>(view, response.data.items.Count));
                }
                else
                {
                    return new ResponseService<ListResult<V>>(response.message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new ResponseService<ListResult<V>>(ex.Message);
            }
        }
    }
}
