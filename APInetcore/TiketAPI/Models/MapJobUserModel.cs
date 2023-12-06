using System;
using TiketAPI.Params;

namespace TiketAPI.Models
{
    public class MapJobUserModel : MapJobUserParam
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
    }
}
