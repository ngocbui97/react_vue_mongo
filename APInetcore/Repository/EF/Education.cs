using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.EF
{
    public partial class Education
    {
        public Education()
        {
            User = new HashSet<User>();
        }

        public Guid id { get; set; }
        public string school_name { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public string department { get; set; }
        public double? score { get; set; }
        public bool? is_have_certificate { get; set; }
        public DateTime? create_time { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
