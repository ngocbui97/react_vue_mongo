using Newtonsoft.Json;
using System;

namespace JobVietAPI.Params
{
    public class UserParam
    {
        public string name { get; set; }
        public string email { get; set; }
        [JsonIgnore]
        public string password { get; set; }
        public int? age { get; set; }
        public string address { get; set; }
        public Guid? role_id { get; set; }
        public bool? active { get; set; }
        public string state { get; set; }
        public string phone { get; set; }
        public DateTime? open_job_time { get; set; }
        public string avatar { get; set; }
        public Guid? education_id { get; set; }
        public string current_position { get; set; }
        public Guid? company_id { get; set; }
        public string code { get; set; }
        public double? year_experience { get; set; }
        public string note { get; set; }
        public string link_cv { get; set; }
        public string user_type { get; set; }
    }
}
