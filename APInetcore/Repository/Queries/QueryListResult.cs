using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Queries
{
    public class QueryListResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; } = 0;
        public QueryListResult(List<T> items, int totalItems)
        {
            Items = items;
            TotalItems = totalItems;
        }
    }
}
