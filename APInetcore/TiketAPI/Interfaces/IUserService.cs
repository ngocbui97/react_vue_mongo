using Repository.EF;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketAPI.Commons;
using TiketAPI.Models;

namespace TiketAPI.Interfaces
{
    public interface IUserService
    {
        Task<ResponseService<QueryListResult<User>>> GetListAsync(QueryParram parram);
        Task<User> GetById(int id);
        Task AddAsync(User user);
        Task Update(User user);
        Task Delete(int id);
        Task<ResponseService<User>> Register(UserModel user);
        Task<ResponseService<UserLoginModel>> Login(string email, string password);
        Task<bool> CheckPermission(int userId, string namePermission);

    }
}
