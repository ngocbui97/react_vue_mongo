using System;

namespace TiketAPI.Params
{
    public class ExperienceParam
    {
        public string position { get; set; }
        public Guid? company_id { get; set; }
        public string project_name { get; set; }
        public string project_description { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public Guid? user_id { get; set; }
    }
}
