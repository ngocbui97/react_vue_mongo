using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class JobService : BaseService<Job>, IJobService
    {
        protected JobService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Job> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
