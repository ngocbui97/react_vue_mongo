﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class TaskJobService : BaseService<TaskJob>, ITaskJobService
    {
        protected TaskJobService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<TaskJob> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
