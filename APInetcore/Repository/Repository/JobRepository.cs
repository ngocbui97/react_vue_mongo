using Repository.EF;
using Repository.Interface;

namespace Repository.Repository
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
    }
}
