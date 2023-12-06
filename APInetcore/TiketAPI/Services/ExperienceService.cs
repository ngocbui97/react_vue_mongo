using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class ExperienceService : BaseService<Experience>, IExperienceService
    {
        public ExperienceService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Experience> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
