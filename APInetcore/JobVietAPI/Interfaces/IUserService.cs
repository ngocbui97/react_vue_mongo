using Repository.CustomModels;
using Repository.EF;
using Repository.Params;
using System;
using System.Threading.Tasks;
using JobVietAPI.Commons;
using JobVietAPI.Models;
using JobVietAPI.Params;

namespace JobVietAPI.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<ResponseService<ListResult<UserInfo>>> GetUsersInfo(SearchUserParam param);
        Task<ResponseService<UserModel>> Register(UserParam user);
        Task<ResponseService<ResponseLoginModel>> Login(string email, string password);
        Task<bool> CheckPermission(Guid userId, string namePermission);
        Task<ResponseService<bool>> ForgotPassword(string email);
        Task<ResponseService<bool>> ResetPassword(string code, string email, string password);
    }
}
