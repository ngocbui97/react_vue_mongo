using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.CustomModels;
using System.Diagnostics;
using TiketAPI.Commons;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class BaseService : BaseParamEntity
    {
        protected readonly IConfiguration _config;
        protected readonly ILoggerManager _logger;
        protected readonly IMapper _mapper;

        protected BaseService(IConfiguration config, ILoggerManager logger, IMapper mapper)
        {
            _config = config;
            _logger = logger;
            _mapper = mapper;
        }
        public static string GetMethodName(StackTrace stackTrace)
        {
            return CommonFunc.GetMethodName(stackTrace);
        }
    }
}
