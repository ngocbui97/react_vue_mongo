using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using JobVietAPI.Interfaces;

namespace JobVietAPI.Services
{
    public class TaskJobService : BaseService<TaskJob>, ITaskJobService
    {
        public TaskJobService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<TaskJob> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
