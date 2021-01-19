using Repository.CustomModels;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T> AddAsync(T obj);
        Task<T> GetByIdAsync(int id);
        Task<ListResult<T>> GetListAsync(QueryParram parram);
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(int id);
    }
}
