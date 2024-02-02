using System;
using System.Runtime.Serialization;

namespace JobVietAPI.Models
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
}
