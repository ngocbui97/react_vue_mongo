using System;

namespace JobVietAPI.Params
{
    public class TaskJobParam 
    {
        public string name { get; set; }
        public Guid? job_id { get; set; }
        public string description { get; set; }
    }
}
