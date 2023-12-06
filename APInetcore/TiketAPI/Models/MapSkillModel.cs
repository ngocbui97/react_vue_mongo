using Repository.EF;
using System;
using TiketAPI.Params;

namespace TiketAPI.Models
{
    public class MapSkillModel : MapSkillParam
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
    }
}
