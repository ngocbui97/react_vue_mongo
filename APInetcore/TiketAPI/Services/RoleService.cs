using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        protected RoleService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Role> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
