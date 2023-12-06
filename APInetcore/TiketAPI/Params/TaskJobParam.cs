using System;

namespace TiketAPI.Params
{
    public class TaskJobParam 
    {
        public string name { get; set; }
        public Guid? job_id { get; set; }
        public string description { get; set; }
    }
}
