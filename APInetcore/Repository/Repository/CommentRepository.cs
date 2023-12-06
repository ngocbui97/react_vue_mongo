using Repository.EF;
using Repository.Interface;

namespace Repository.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
    }
}
