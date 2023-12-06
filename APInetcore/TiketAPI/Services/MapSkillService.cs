﻿using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class MapSkillService : BaseService<MapSkill>, IMapSkillService
    {
        public MapSkillService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<MapSkill> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
