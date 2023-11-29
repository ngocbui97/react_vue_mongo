using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.EF
{
    public partial class Job
    {
        public Job()
        {
            Comment = new HashSet<Comment>();
            MapJobUser = new HashSet<MapJobUser>();
            MapSkill = new HashSet<MapSkill>();
            Task_Job = new HashSet<Task_Job>();
        }

        public Guid id { get; set; }
        public string position { get; set; }
        public string description { get; set; }
        public string language_communicate { get; set; }
        public int? experience_year { get; set; }
        public string file_attach { get; set; }
        public Guid? company_id { get; set; }
        public string language_code { get; set; }
        public DateTime? create_time { get; set; }
        public DateTime? modify_time { get; set; }
        public DateTime? stat_time { get; set; }
        public DateTime? end_time { get; set; }
        public string create_by { get; set; }
        public string modify_by { get; set; }
        public string state { get; set; }
        public string salary { get; set; }
        public bool? is_remote { get; set; }
        public bool? is_freelance { get; set; }
        public string level { get; set; }
        public string type_job { get; set; }
        public Guid? user_id { get; set; }
        public string city { get; set; }
        public string contact_info { get; set; }

        public virtual Company company_ { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<MapJobUser> MapJobUser { get; set; }
        public virtual ICollection<MapSkill> MapSkill { get; set; }
        public virtual ICollection<Task_Job> Task_Job { get; set; }
    }
}
