using System;
using TiketAPI.Params;

namespace TiketAPI.Models
{
    public class RoleModel : RoleParam
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
    }
}
