using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class SkillService : BaseService<Skill>, ISkillService
    {
        protected SkillService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Skill> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
