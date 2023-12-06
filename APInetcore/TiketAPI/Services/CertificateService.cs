using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class CertificateService : BaseService<Certificate>, ICertificateService
    {
        public CertificateService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Certificate> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
