using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class EducationService : BaseService<Education>, IEducationService
    {
        protected EducationService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Education> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
