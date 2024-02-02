using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using JobVietAPI.Interfaces;

namespace JobVietAPI.Services
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Company> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
