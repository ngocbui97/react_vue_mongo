using Repository.EF;
using TiketAPI.Models;
using TiketAPI.Params;
using Profile = AutoMapper.Profile;

namespace TiketAPI.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<User, UserParam>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, ResponseLoginModel>().ReverseMap();

            CreateMap<TaskJobParam, TaskJob>().ReverseMap();
            CreateMap<TaskJobModel, TaskJob>().ReverseMap();

            CreateMap<SkillParam, Skill>().ReverseMap();
            CreateMap<SkillModel, Skill>().ReverseMap();

            CreateMap<RoleParam, Role>().ReverseMap();
            CreateMap<RoleModel, Role>().ReverseMap();

            CreateMap<MapSkillParam, MapSkill>().ReverseMap();
            CreateMap<MapSkillModel, MapSkill>().ReverseMap();

            CreateMap<MapJobUserParam, MapJobUser>().ReverseMap();
            CreateMap<MapJobUserModel, MapJobUser>().ReverseMap();

            CreateMap<JobParam, Job>().ReverseMap();
            CreateMap<JobModel, Job>().ReverseMap();

            CreateMap<ExperienceParam, Experience>().ReverseMap();
            CreateMap<ExperienceModel, Experience>().ReverseMap();

            CreateMap<EducationParam, Education>().ReverseMap();
            CreateMap<EducationModel, Education>().ReverseMap();

            CreateMap<ConversationParam, Conversation>().ReverseMap();
            CreateMap<ConversationModel, Conversation>().ReverseMap();

            CreateMap<CompanyParam, Company>().ReverseMap();
            CreateMap<CompanyModel, Company>().ReverseMap();

            CreateMap<CommentParam, Comment>().ReverseMap();
            CreateMap<CommentModel, Comment>().ReverseMap();

            CreateMap<CertificateParam, Certificate>().ReverseMap();
            CreateMap<CertificateModel, Certificate>().ReverseMap();
        }
    }
}
