using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class MapJobUserService : BaseService<MapJobUser>, IMapJobUserService
    {
        public MapJobUserService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<MapJobUser> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
