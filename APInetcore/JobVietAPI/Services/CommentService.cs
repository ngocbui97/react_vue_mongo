using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repository.EF;
using Repository.Interface;
using JobVietAPI.Interfaces;

namespace JobVietAPI.Services
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(IConfiguration config, ILoggerManager logger, IMapper mapper, IRepository<Comment> baseRepository) : base(config, logger, mapper, baseRepository)
        {
        }
    }
}
