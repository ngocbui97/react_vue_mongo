using System;
using TiketAPI.Params;

namespace TiketAPI.Models
{
    public class SkillModel : SkillParam
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime? create_time { get; set; }
    }
}
