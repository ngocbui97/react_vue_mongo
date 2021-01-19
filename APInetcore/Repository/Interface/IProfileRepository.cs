using AutoMapper;
using Repository.EF;
using Repository.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Profile = Repository.EF.Profile;

namespace Repository.Interface
{
    public interface IProfileRepository : IRepository<Profile>
    {
    }
}
