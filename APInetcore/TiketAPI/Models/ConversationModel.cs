using System;
using TiketAPI.Params;

namespace TiketAPI.Models
{
    public class ConversationModel : ConversationParam
    {
        public Guid id { get; set; }
        public DateTime? create_time { get; set; }
    }
}
