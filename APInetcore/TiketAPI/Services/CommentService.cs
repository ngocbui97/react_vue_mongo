using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using TiketAPI.Interfaces;

namespace TiketAPI.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        protected CommentService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Comment> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
