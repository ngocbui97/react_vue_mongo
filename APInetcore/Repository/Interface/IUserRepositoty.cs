using Repository.CustomModels;
using Repository.EF;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepositoty : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);

        Task<Boolean> CheckPermission(int id, string namePermission); 
    }
}
