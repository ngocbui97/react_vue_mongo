using System.Collections.Generic;

namespace Repository.CustomModels
{
    public class ListResult<T>
    {
        public List<T> items { get; set; } = new List<T>();
        public int total { get; set; } = 0;
        public ListResult(List<T> items, int total)
        {
            this.items = items;
            this.total = total;
        }
    }
    public class Total
    {
        public int total { get; set; }
    }
}
