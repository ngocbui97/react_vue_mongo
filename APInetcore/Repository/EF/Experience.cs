using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.EF
{
    public partial class Experience
    {
        public Guid id { get; set; }
        public string position { get; set; }
        public Guid? company_id { get; set; }
        public string project_name { get; set; }
        public string project_description { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public Guid? user_id { get; set; }

        public virtual Company company_ { get; set; }
        public virtual User user_ { get; set; }
    }
}
