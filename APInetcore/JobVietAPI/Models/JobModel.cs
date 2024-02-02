using System;
using JobVietAPI.Params;

namespace JobVietAPI.Models
{
    public class JobModel : JobParam
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
        public DateTime? modify_time { get; set; }
        public string create_by { get; set; }
        public string modify_by { get; set; }
    }
}
