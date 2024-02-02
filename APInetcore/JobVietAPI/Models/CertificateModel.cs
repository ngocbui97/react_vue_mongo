using System;
using JobVietAPI.Params;

namespace JobVietAPI.Models
{
    public class CertificateModel : CertificateParam
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
        public DateTime? modify_time { get; set; }
    }
}
