using Repository.CustomModels;
using System.Threading.Tasks;
using System;
using TiketAPI.Commons;

namespace TiketAPI.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<ResponseService<ListResult<T>>> GetListAsync(PagingParam parram);
        Task<ResponseService<ListResult<V>>> GetListAsync<V>(PagingParam parram);
        Task<ResponseService<T>> GetById(Guid id);
        Task<ResponseService<V>> GetById<V>(Guid id);
        Task<ResponseService<T>> Update(Guid id, T item);
        Task<ResponseService<V>> Update<V>(Guid id, Object item);
        Task<ResponseService<T>> Create(T item);
        Task<ResponseService<V>> Create<V>(Object item);
        Task<ResponseService<bool>> Delete(Guid id);
    }
}
