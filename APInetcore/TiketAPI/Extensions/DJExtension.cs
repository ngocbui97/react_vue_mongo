using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interface;
using Repository.Repository;
using TiketAPI.Interfaces;
using TiketAPI.Services;

namespace TiketAPI.Extensions
{
    public static class DJExtension
    {
        public static void ConfigDependencyInjection(this IServiceCollection services)
        {
            // Inject repository
            services.AddSingleton(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ISkillRepository, SkillRepository>();
            services.AddSingleton<ITaskJobRepository, TaskJobRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<IMapSkillRepository, MapSkillRepository>();
            services.AddSingleton<IMapJobUserRepository, MapJobUserRepository>();
            services.AddSingleton<IJobRepository, JobRepository>();
            services.AddSingleton<IExperienceRepository, ExperienceRepository>();
            services.AddSingleton<IEducationRepository, EducationRepository>();
            services.AddSingleton<IConversationRepository, ConversationRepository>();
            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<ICertificateRepository, CertificateRepository>();

            // Inject service
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ISkillService, SkillService>();
            services.AddSingleton<ITaskJobService, TaskJobService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<IMapSkillService, MapSkillService>();
            services.AddSingleton<IMapJobUserService, MapJobUserService>();
            services.AddSingleton<IJobService, JobService>();
            services.AddSingleton<IExperienceService, ExperienceService>();
            services.AddSingleton<IEducationService, EducationService>();
            services.AddSingleton<IConversationService, ConversationService>();
            services.AddSingleton<ICompanyService, CompanyService>();
            services.AddSingleton<ICommentService, CommentService>();
            services.AddSingleton<ICertificateService, CertificateService>();
        }
    }
}
