using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class ConversationService : BaseService<Conversation>, IConversationService
    {
        public ConversationService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Conversation> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
