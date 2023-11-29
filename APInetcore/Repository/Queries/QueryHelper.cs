using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Repository.Queries
{
    public static class QueryHelper
    {
        public static object GetValueObject(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }
        public static SqlParameter[] ToListParam(object obj, string str_fields)
        {
            List<SqlParameter> paramsQuery = new List<SqlParameter>();
            var fields = str_fields.Replace(" ","").Split(",");
            
            foreach(string field in fields)
            {
                paramsQuery.Add(new SqlParameter($"@{field}", GetValueObject(obj, field)));
            }

            return paramsQuery.ToArray();
        }
    }
}
