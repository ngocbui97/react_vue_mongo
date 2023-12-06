using Repository.CustomModels;
using Repository.EF;
using Repository.Params;
using System;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<Boolean> CheckPermission(Guid id, string namePermission);
        Task<ListResult<UserInfo>> GetUsersInfo(SearchUserParam param);
    }
}
