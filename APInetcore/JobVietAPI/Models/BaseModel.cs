using System;

namespace JobVietAPI.Models
{
    public class BaseModel
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
    }
}
