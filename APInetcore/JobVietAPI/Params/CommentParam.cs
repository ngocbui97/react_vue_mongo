using System;

namespace JobVietAPI.Params
{
    public class CommentParam
    {
        public Guid? job_id { get; set; }
        public Guid? company_id { get; set; }
        public Guid? parent_id { get; set; }
        public string message { get; set; }
        public Guid? user_id { get; set; }
        public bool? is_active { get; set; }
    }
}
