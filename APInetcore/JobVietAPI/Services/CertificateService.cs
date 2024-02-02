using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using JobVietAPI.Interfaces;

namespace JobVietAPI.Services
{
    public class CertificateService : BaseService<Certificate>, ICertificateService
    {
        public CertificateService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Certificate> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
