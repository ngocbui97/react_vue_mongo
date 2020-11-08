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
    public class UserRepository : BaseRepository, IUserRepositoty
    {
        public UserRepository() : base() { }
        public async Task<int> AddAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> CheckPermission(int id, string namePermission)
        {
            User functionUser = await _db.Users.Where(u => u.Id == id && u.Active && u.Role.RoleFunction)
                                .Include(u => u.Role)
                                .ThenInclude(r => r.RoleFunction)
                                .ThenInclude(f => f.Function)
                                .FirstOrDefaultAsync();
            if (functionUser != null) return true;
            return false;
        }

        public async void Delete(User user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<QueryListResult<User>> GetListAsync(QueryParram parram)
        {
            IQueryable<User> queryUser = _db.Users.AsNoTracking();
            List<User> users = await queryUser.Skip(parram.Page - 1 * parram.Limit).Take(parram.Limit).ToListAsync<User>();
            int totalUser = await queryUser.CountAsync();
            return new QueryListResult<User>(users, totalUser);
        }

        public async void Update(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
