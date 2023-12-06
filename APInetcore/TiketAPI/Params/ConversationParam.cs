using System;

namespace TiketAPI.Params
{
    public class ConversationParam
    {
        public Guid? to_user_id { get; set; }
        public string message { get; set; }
        public Guid? from_user_id { get; set; }
        public bool? is_active { get; set; }
    }
}
