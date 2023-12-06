using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.EF
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool? is_active { get; set; }
        public DateTime? create_time { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
