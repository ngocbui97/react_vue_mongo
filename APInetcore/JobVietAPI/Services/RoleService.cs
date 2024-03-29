﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using JobVietAPI.Interfaces;

namespace JobVietAPI.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        public RoleService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Role> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
