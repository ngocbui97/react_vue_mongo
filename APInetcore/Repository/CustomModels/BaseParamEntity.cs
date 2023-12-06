using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace Repository.CustomModels
{
    public class BaseParamEntity
    {
        public ProEntity[] Pros(string field_name, object value)
        {
            return new ProEntity[] { new ProEntity(field_name, value) };
        }
        public ProEntity[] Pros(params ProEntity[] pros)
        {
            return pros;
        }
        public ProEntity[] Pros()
        {
            return new ProEntity[] { };
        }
    }
    public class ProEntity
    {
        public string field_name { get; set; }
        public object value { get; set; }
        public ProEntity(string field_name, object value)
        {
            this.field_name = field_name;
            this.value = value;
        }
    }
    public class SearchField
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class SortField
    {
        public string name { get; set; }
        [OneOf("desc","asc")]
        public string value { get; set; }
    }
    public class PagingParam
    {
        public int page { get; set; } = 1;
        public int limit { get; set; } = 10;
        public List<SearchField> searchs { get; set; } = new List<SearchField>();
        public string col_sort { get; set; }
        public string type_sort { get; set; }
        public SqlParameter[] ToSqlParrams()
        {
            List<SqlParameter> pa = new List<SqlParameter>();
            searchs.ForEach(search => pa.Add(new SqlParameter($"@{search.name}", search.value)));
            pa.Add(new SqlParameter("@col_sort", col_sort));
            pa.Add(new SqlParameter("@type_sort ", type_sort));
            pa.Add(new SqlParameter("@page", page));
            pa.Add(new SqlParameter("@limit", limit));
            return pa.ToArray();
        }
    }
    public class OneOfAttribute : ValidationAttribute
    {
        public int[] ItemInt { get; set; }
        public string[] ItemString { get; set; }
        public OneOfAttribute(params int[] items) : base("{0} value is not in " + String.Join(",", items))
        {
            this.ItemInt = items;
        }
        public OneOfAttribute(params string[] items) : base("{0} value is not in " + String.Join(",", items))
        {
            this.ItemString = items;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (ItemInt!=null && ItemInt.Length > 0)
            {
                int val = (int)value;
                if (!ItemInt.Contains(val))
                {
                    return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                                                , new string[] { validationContext.MemberName });
                }
                return null;
            }
            else if(ItemString!=null)
            {
                string val = (string)value;
                if (!ItemString.Contains(val))
                {
                    return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                                                , new string[] { validationContext.MemberName });
                }
                return null;
            }
            return null;
        }
    }
    public class InputProcedure
    {
        public string query { get; set; }
        public SqlParameter[] param { get; set; }
        public string name { get; set; }
        public InputProcedure(string name, params SqlParameter[] paramSqls)
        {
            this.name = name;
            this.param = ConvertValueParams(paramSqls);

            string query = $"exec {name} ";
            query += String.Join(", ", paramSqls.Select(item =>
            item.Direction != ParameterDirection.Output ? item.ParameterName : $"{item.ParameterName} out"
            ).ToList());

            this.query = query;
        }
        private SqlParameter[] ConvertValueParams(params SqlParameter[] paramSqls)
        {
            foreach (var param in paramSqls)
            {
                if (param.Value == null) param.Value = DBNull.Value;
            }
            return paramSqls;
        }
    }
}
