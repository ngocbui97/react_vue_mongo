using System;
using System.Runtime.Serialization;

namespace TiketAPI.Models
{
    public class ItemModel
    {
        public Guid id { get; set; }
    }
    public class IgnoreItemModel
    {
        [IgnoreDataMember]
        public Guid id { get; set; }
    }

    public class BaseModel : IgnoreItemModel
    {
        public DateTime? create_time { get; set; }
        public DateTime? modify_time { get; set; }
        public string create_by { get; set; }
        public string modify_by { get; set; }

        public void AddInfo(string by = null)
        {
            this.id = Guid.NewGuid();
            this.create_time = this.modify_time = DateTime.Now;
            this.create_by = this.modify_by = by;
        }
    }
}
