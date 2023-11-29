using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.EF
{
    public partial class Comment
    {
        public Guid id { get; set; }
        public Guid? job_id { get; set; }
        public Guid? company_id { get; set; }
        public Guid? parent_id { get; set; }
        public string message { get; set; }
        public Guid? create_by { get; set; }
        public DateTime? create_time { get; set; }
        public bool? is_active { get; set; }

        public virtual Company company_ { get; set; }
        public virtual User create_byNavigation { get; set; }
        public virtual Job job_ { get; set; }
    }
}
