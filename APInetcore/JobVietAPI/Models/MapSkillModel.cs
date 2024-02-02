using Repository.EF;
using System;
using JobVietAPI.Params;

namespace JobVietAPI.Models
{
    public class MapSkillModel : MapSkillParam
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
    }
}
