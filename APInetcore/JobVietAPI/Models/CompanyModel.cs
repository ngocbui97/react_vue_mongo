using System;
using JobVietAPI.Params;

namespace JobVietAPI.Models
{
    public class CompanyModel : CompanyParam
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
    }
}
