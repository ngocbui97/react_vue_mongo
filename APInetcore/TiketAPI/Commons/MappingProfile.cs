using Repository.CustomModels;
using Repository.EF;
using System.Collections.Generic;
using TiketAPI.Models;
using Profile = AutoMapper.Profile;

namespace TiketAPI.Commons
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, ResponseLoginModel>().ReverseMap();
        }
    }
}
