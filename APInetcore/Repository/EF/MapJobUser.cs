using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.EF
{
    public partial class MapJobUser
    {
        public Guid id { get; set; }
        public Guid? job_id { get; set; }
        public Guid? user_id { get; set; }
        public DateTime? create_time { get; set; }

        public virtual Job user_ { get; set; }
        public virtual User user_Navigation { get; set; }
    }
}
