using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Repository.EF
{
    public partial class Skill
    {
        public Skill()
        {
            MapSkill = new HashSet<MapSkill>();
        }

        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime? create_time { get; set; }

        public virtual ICollection<MapSkill> MapSkill { get; set; }
    }
}
