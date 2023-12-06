using System;
using TiketAPI.Params;

namespace TiketAPI.Models
{
    public class EducationModel : EducationParam
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
    }
}
