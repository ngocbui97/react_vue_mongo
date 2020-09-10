using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.EF
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Profile = new HashSet<Profile>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Profile> Profile { get; set; }
    }
}
