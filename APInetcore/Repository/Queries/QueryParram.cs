using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Queries
{
    public class QueryParram
    {
        public int Page { get; protected set; }
        public int Limit { get; protected set; }

        public QueryParram(int page, int limit)
        {
            Page = page;
            Limit = limit;

            if (Page <= 0)
            {
                Page = 1;
            }

            if (Limit <= 0)
            {
                Limit = 10;
            }
        }
    }
}
