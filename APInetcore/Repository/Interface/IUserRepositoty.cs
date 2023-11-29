using Repository.CustomModels;
using Repository.EF;
using Repository.Params;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepositoty : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<Boolean> CheckPermission(Guid id, string namePermission);
        Task<ListResult<UserInfo>> GetUsersInfo(SearchUserParam param);
    }
}
