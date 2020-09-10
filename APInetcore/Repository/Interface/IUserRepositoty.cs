using Repository.EF;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepositoty
    {
        Task<QueryListResult<User>> GetListAsync(QueryParram parram);
        Task<User> GetByIdAsync(int id);
        Task<int> AddAsync(User user);
        void Update(User user);
        void Delete(User user);
        Task<User> GetByEmailAsync(string email);
    }
}
