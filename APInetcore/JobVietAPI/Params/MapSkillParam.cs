using System;

namespace JobVietAPI.Params
{
    public class MapSkillParam
    {
        public Guid? job_id { get; set; }
        public Guid? user_id { get; set; }
        public Guid? skill_id { get; set; }
    }
}
