using System;

namespace JobVietAPI.Params
{
    public class EducationParam
    {
        public string school_name { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public string department { get; set; }
        public double? score { get; set; }
        public bool? is_have_certificate { get; set; }
    }
}
