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
}
