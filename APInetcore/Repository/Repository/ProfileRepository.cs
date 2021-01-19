using Microsoft.EntityFrameworkCore;
using Repository.CustomModels;
using Repository.EF;
using Repository.Interface;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository() : base() { }
    }
}
