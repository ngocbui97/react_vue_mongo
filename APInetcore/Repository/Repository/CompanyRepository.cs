using Repository.EF;
using Repository.Interface;

namespace Repository.Repository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
    }
}
