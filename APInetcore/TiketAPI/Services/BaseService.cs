using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class BaseService
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
    }
}
