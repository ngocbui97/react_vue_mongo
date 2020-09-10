using Repository.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public abstract class BaseRepository
    {
        protected readonly ticketContext _db;
        public BaseRepository()
        {
            _db = new ticketContext();
        }
    }
}
