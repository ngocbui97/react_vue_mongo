using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using JobVietAPI.Config;
using JobVietAPI.Interfaces;
using JobVietAPI.Models;

namespace JobVietAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        private static readonly IMapper _mapper = ConfigContainerDJ.CreateIntance<IMapper>();
        private static ILoggerManager _logger = ConfigContainerDJ.CreateIntance<ILoggerManager>();

        /// <summary>
        /// convert response list result type T to V
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public RequestModel<V> ConvertToRequest<V>(Object data, bool isNewInfo = true)
        {
            RequestModel<V> request = new RequestModel<V> {};
            try
            {
                V view = _mapper.Map<V>(data);
                request.data = view;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                request.ex = ex;
            }

            return request;
        }
    }
}
