using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using JobVietAPI.Interfaces;

namespace JobVietAPI.Services
{
    public class JobService : BaseService<Job>, IJobService
    {
        public JobService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Job> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
