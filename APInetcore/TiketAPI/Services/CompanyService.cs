using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        protected CompanyService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Company> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
