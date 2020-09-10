using AutoMapper;
using Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketAPI.Models;
using Profile = AutoMapper.Profile;

namespace TiketAPI.Commons
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
            CreateMap<User, UserLoginModel>();
        }
    }
}
