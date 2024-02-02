using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using JobVietAPI.Interfaces;

namespace JobVietAPI.Services
{
    public class EducationService : BaseService<Education>, IEducationService
    {
        public EducationService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Education> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
