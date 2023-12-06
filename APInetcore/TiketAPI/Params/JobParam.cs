using System;

namespace TiketAPI.Params
{
    public class JobParam
    {
        public string position { get; set; }
        public string description { get; set; }
        public string language_communicate { get; set; }
        public int? experience_year { get; set; }
        public string file_attach { get; set; }
        public Guid? company_id { get; set; }
        public string language_code { get; set; }
        public DateTime? stat_time { get; set; }
        public DateTime? end_time { get; set; }
        public string state { get; set; }
        public string salary { get; set; }
        public bool? is_remote { get; set; }
        public bool? is_freelance { get; set; }
        public string level { get; set; }
        public string type_job { get; set; }
        public Guid? user_id { get; set; }
        public string city { get; set; }
        public string contact_info { get; set; }
    }
}
