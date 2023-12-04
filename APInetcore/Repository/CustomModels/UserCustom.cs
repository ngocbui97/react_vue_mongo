using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.CustomModels
{
    internal class UserCustom
    {
    }
    public class UserInfo
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public Guid? role_id { get; set; }
        public bool active { get; set; }
        public DateTime? create_time { get; set; }
        public DateTime? modify_time { get; set; }
        public string create_by { get; set; }
        public string modify_by { get; set; }
        public string state { get; set; }
        public string phone { get; set; }
        public DateTime open_job_time { get; set; }
        public string avatar { get; set; }
        public Guid? education_id { get; set; }
        public string current_position { get; set; }
        public Guid? company_id { get; set; }
        public double? year_experience { get; set; }
        public string note { get; set; }
        public string link_cv { get; set; }
    }
}
