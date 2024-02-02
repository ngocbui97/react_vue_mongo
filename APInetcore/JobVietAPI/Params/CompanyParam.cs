using System;

namespace JobVietAPI.Params
{
    public class CompanyParam
    {
        public string name { get; set; }
        public string address { get; set; }
        public string department { get; set; }
        public string description { get; set; }
        public string logo { get; set; }
        public DateTime? start_time { get; set; }
    }
}
