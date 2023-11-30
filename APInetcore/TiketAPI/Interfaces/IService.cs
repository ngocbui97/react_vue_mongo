using Repository.CustomModels;
using Repository.EF;
using System.Threading.Tasks;
using System;
using TiketAPI.Commons;

namespace TiketAPI.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<ResponseService<ListResult<T>>> GetListAsync(PagingParam parram);
        Task<ResponseService<T>> GetById(Guid id);
        Task<ResponseService<T>> Update(Guid id, T item);
        Task<ResponseService<T>> Create(T item);
        Task<ResponseService<bool>> Delete(Guid id);
    }
}
