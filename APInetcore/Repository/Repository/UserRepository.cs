using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Repository.EF;
using Repository.Interface;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepositoty
    {
        public UserRepository() : base() { }

        public async Task<bool> CheckPermission(int id, string namePermission)
        {
            User functionUser = await _db.Users.Where(u => u.Id == id && u.Active)
                                .Include(u => u.Role)
                                .ThenInclude(r => r.RoleFunction)
                                .ThenInclude(f => f.Function.Name == namePermission)
                                .FirstOrDefaultAsync();
            if (functionUser != null) return true;
            return false;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
