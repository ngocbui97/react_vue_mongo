using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.EF
{
    public partial class User
    {
        public User()
        {
            Certificate = new HashSet<Certificate>();
            Comment = new HashSet<Comment>();
            Conversationfrom_user_ = new HashSet<Conversation>();
            Conversationto_user_ = new HashSet<Conversation>();
            Experience = new HashSet<Experience>();
            MapJobUser = new HashSet<MapJobUser>();
            MapSkill = new HashSet<MapSkill>();
        }

        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int? age { get; set; }
        public string address { get; set; }
        public Guid? role_id { get; set; }
        public bool? active { get; set; }
        public DateTime? create_time { get; set; }
        public DateTime? modify_time { get; set; }
        public string create_by { get; set; }
        public string modify_by { get; set; }
        public string state { get; set; }
        public string phone { get; set; }
        public DateTime? open_job_time { get; set; }
        public string avatar { get; set; }
        public Guid? education_id { get; set; }
        public string current_position { get; set; }
        public Guid? company_id { get; set; }
        public string code { get; set; }
        public double? year_experience { get; set; }
        public string note { get; set; }
        public string link_cv { get; set; }
        public string user_type { get; set; }

        public virtual Company company_ { get; set; }
        public virtual Education education_ { get; set; }
        public virtual Role role_ { get; set; }
        public virtual ICollection<Certificate> Certificate { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Conversation> Conversationfrom_user_ { get; set; }
        public virtual ICollection<Conversation> Conversationto_user_ { get; set; }
        public virtual ICollection<Experience> Experience { get; set; }
        public virtual ICollection<MapJobUser> MapJobUser { get; set; }
        public virtual ICollection<MapSkill> MapSkill { get; set; }
    }
}
