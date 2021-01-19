using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.CustomModels
{
    public class ListResult<T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int TotalItems { get; set; } = 0;
        public ListResult(List<T> items, int totalItems)
        {
            Items = items;
            TotalItems = totalItems;
        }
    }
}
