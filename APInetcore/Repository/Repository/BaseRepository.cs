using Microsoft.EntityFrameworkCore;
using Repository.CustomModels;
using Repository.EF;
using Repository.Interface;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ticketContext _db;
        public BaseRepository()
        {
            _db = new ticketContext();
        }

        #region implement
        public virtual async Task<T> AddAsync(T obj)
        {
            await _db.Set<T>().AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public virtual async Task<ListResult<T>> GetListAsync(QueryParram parram)
        {
            IQueryable<T> query = _db.Set<T>().AsNoTracking();
            List<T> datas = await query.Skip(parram.Page - 1 * parram.Limit).Take(parram.Limit).ToListAsync<T>();
            int total = await query.CountAsync();
            return new ListResult<T>(datas, total);
        }

        [Obsolete]
        public async virtual Task<T> UpdateAsync(T obj)
        {
            _db.Set<T>().Update(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async virtual Task<bool> DeleteAsync(int id)
        {
            var itemDelete =  await _db.Set<T>().FindAsync(id);
            _db.Set<T>().Remove(itemDelete);
            await _db.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
