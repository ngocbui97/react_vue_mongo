using Microsoft.Data.SqlClient;
using Repository.CustomModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T> Create(T obj);
        Task<List<T>> CreateList(List<T> listObj);
        Task<T> GetById(object obj);
        Task<List<T>> GetListByField(string field, object obj, Guid? tenant_id = null);
        Task<T> GetByField(string field, object obj, Guid? tenant_id = null);
        Task<ListResult<T>> GetAll(PagingParam parram);
        Task<T> Update(object objId, T obj);
        Task<T> Update(object objId, ProEntity[] pros);
        Task<bool> Delete(object obj);
    }
}
