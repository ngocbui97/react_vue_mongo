using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.EF
{
    public partial class Conversation
    {
        public Guid id { get; set; }
        public Guid? to_user_id { get; set; }
        public string message { get; set; }
        public DateTime? create_time { get; set; }
        public Guid? create_by { get; set; }
        public bool? is_active { get; set; }

        public virtual User create_byNavigation { get; set; }
        public virtual User to_user_ { get; set; }
    }
}
