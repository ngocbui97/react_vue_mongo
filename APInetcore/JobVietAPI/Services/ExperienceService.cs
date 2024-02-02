using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using JobVietAPI.Interfaces;

namespace JobVietAPI.Services
{
    public class ExperienceService : BaseService<Experience>, IExperienceService
    {
        public ExperienceService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Experience> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
