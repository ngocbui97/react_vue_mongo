using System;
using JobVietAPI.Params;

namespace JobVietAPI.Models
{
    public class SkillModel : SkillParam
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime? create_time { get; set; }
    }
}
