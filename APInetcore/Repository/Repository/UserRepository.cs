using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repository.CustomModels;
using Repository.EF;
using Repository.Extension;
using Repository.Interface;
using Repository.Params;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository() : base() { }

        public async Task<bool> CheckPermission(Guid id, string namePermission)
        {
            //User functionUser = await _db.User.Where(u => u.id == id && u.active)
            //                    .Include(u => u.Role)
            //                    .ThenInclude(r => r.RoleFunction)
            //                    .ThenInclude(f => f.Function.Name == namePermission)
            //                    .FirstOrDefaultAsync();
            //if (functionUser != null) return true;
            return false;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _db.User.AsNoTracking().FirstOrDefaultAsync(user => user.email == email);
        }
        public async Task<ListResult<UserInfo>> GetUsersInfo(SearchUserParam param)
        {
            string fields = "name, email, age_from, age_to, address, state, phone, current_position, col_sort, type_sort, page, limit";
            SqlParameter[] paramUser = QueryHelper.ToListParam(param, fields);
            InputProcedure inputUser = new InputProcedure(Procedure.GET_USERS_INFO, paramUser);

            var dataUsers = await CallProcedure(inputUser);

            List<UserInfo> users = dataUsers[0].ConvertToList<UserInfo>();
            int total = dataUsers[1].Rows[0].Field<int>("total");

            return new ListResult<UserInfo>(users, total);
        }
    }
}
