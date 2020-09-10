using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.EF
{
    [Table("Profile")]
    public partial class Profile
    {
        public int Id { get; set; }
        public string CurrentPosition { get; set; }
        public string University { get; set; }
        public int Status { get; set; }
        public string ExpectPosition { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
