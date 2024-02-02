using System;

namespace JobVietAPI.Params
{
    public class CertificateParam
    {
        public string name { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public Guid? user_id { get; set; }
    }
}
