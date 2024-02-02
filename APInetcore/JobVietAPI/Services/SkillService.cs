using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using JobVietAPI.Interfaces;

namespace JobVietAPI.Services
{
    public class SkillService : BaseService<Skill>, ISkillService
    {
        public SkillService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Skill> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
