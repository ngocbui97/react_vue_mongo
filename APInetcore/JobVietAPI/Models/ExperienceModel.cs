using System;
using JobVietAPI.Params;

namespace JobVietAPI.Models
{
    public class ExperienceModel : ExperienceParam
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
    }
}
