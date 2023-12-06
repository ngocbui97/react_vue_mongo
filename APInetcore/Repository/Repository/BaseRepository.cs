using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repository.CustomContext;
using Repository.CustomModels;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Repository.Repository
{
    public class BaseRepository<T> : BaseParamEntity, IRepository<T> where T : class, new()
    {
        protected readonly DbContextCustom _db;
        public BaseRepository()
        {
            _db = new DbContextCustom();
        }
        #region implement
        public virtual async Task<T> Create(T obj)
        {
            _db.Set<T>().Add(obj);
            await _db.SaveChangesAsync();
            return obj;
        }
        public virtual async Task<List<T>> CreateList(List<T> listObj)
        {
            _db.Set<T>().AddRange(listObj);
            await _db.SaveChangesAsync();
            return listObj;
        }

        public virtual async Task<T> GetById(object obj)
        {
            if (obj == null) return null;
            return await _db.Set<T>().FindAsync(Guid.Parse(obj.ToString()));
        }
        public virtual async Task<T> GetByField(string field, object objId, Guid? tenant_id = null)
        {
            if (tenant_id != null) return await _db.Set<T>().Where($"{field} == @0 and tenant_id == @1", objId, tenant_id).AsNoTracking().FirstOrDefaultAsync();
            return await _db.Set<T>().Where($"{field} == @0", objId).AsNoTracking().FirstOrDefaultAsync();
        }
        public virtual async Task<List<T>> GetListByField(string field, object objId, Guid? tenant_id = null)
        {
            if (tenant_id != null) return await _db.Set<T>().Where($"{field} == @0 and tenant_id == @1", objId, tenant_id).AsNoTracking().ToListAsync();
            return await _db.Set<T>().Where($"{field} == @0", objId).AsNoTracking().ToListAsync();
        }
        public virtual async Task<ListResult<T>> GetAll(PagingParam param)
        {
            IQueryable<T> query = _db.Set<T>().AsNoTracking().OrderBy("create_time");

            List<T> datas = new List<T>();

            if (param != null && param.page != 0 && param.limit != 0)
            {
                datas = await query.Skip(((param.page - 1) * param.limit)).Take(param.limit).ToListAsync<T>();
            }
            else
            {
                datas = await query.ToListAsync<T>();
            }

            return new ListResult<T>(datas, datas.Count);
        }

        public async virtual Task<T> Update(object objId, T obj)
        {
            var entity = await _db.Set<T>().FindAsync(objId);
            if (entity == null)
            {
                return null;
            }

            _db.Entry(entity).CurrentValues.SetValues(obj);
            await _db.SaveChangesAsync();

            return obj;
        }

        public async virtual Task<T> Update(object objId, ProEntity[] pros)
        {
            if (pros.Count() == 0) return null;
            var expressCondition = ExpressionCommon.ConditionExpression<T>(Pros("id", objId));
            var expressUpdate = ExpressionCommon.UpdateExpression<T>(pros);
            await _db.Set<T>().Where(expressCondition).UpdateAsync(expressUpdate);
            return default;
        }

        public async virtual Task<bool> Delete(object obj)
        {
            if (obj == null) return false;
            var expressCondition = ExpressionCommon.ConditionExpression<T>(Pros("id", obj));
            await _db.Set<T>().Where(expressCondition).DeleteAsync();
            return true;
        }

        public async Task<List<DataTable>> CallProcedure(InputProcedure input)
        {
            List<DataTable> tables = new List<DataTable>();
            using (var command = _db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = input.name;
                command.CommandType = CommandType.StoredProcedure;
                input.param.ToList().ForEach(item => command.Parameters.Add(item));

                _db.Database.OpenConnection();
                using (var result = await command.ExecuteReaderAsync())
                {
                    while (!result.IsClosed)
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(result);
                        tables.Add(dataTable);
                    }
                }
            }
            return tables;
        }
        public List<Template> ConvertToList<Template>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>()
                    .Select(c => c.ColumnName)
                    .ToList();
            var properties = typeof(Template).GetProperties();
            return dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<Template>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();
        }
        #endregion

        #region common handle logic
        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
        public static Template Cast<Template>(object obj)
        {
            var jsonObject = JsonSerializer.Serialize(obj);
            var dataObject = JsonSerializer.Deserialize<Template>(jsonObject);
            return dataObject;
        }
        public static string GetMethodName(StackTrace stackTrace)
        {
            var method = stackTrace.GetFrame(0).GetMethod();

            string _methodName = method.DeclaringType.FullName;

            if (_methodName.Contains(">") || _methodName.Contains("<"))
            {
                _methodName = _methodName.Split('<', '>')[1];
            }
            else
            {
                _methodName = method.Name;
            }

            return _methodName;
        }
        private SqlParameter[] ConvertValueParams(params SqlParameter[] paramSqls)
        {
            foreach (var param in paramSqls)
            {
                if (param.Value == null) param.Value = DBNull.Value;
            }
            return paramSqls;
        }
        #endregion
    }
}
