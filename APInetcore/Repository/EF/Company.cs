using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.EF
{
    public partial class Company
    {
        public Company()
        {
            Comment = new HashSet<Comment>();
            Experience = new HashSet<Experience>();
            Job = new HashSet<Job>();
            User = new HashSet<User>();
        }

        public Guid id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public string description { get; set; }
        public string logo { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? create_time { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Experience> Experience { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
