using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.EF
{
    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            RoleFunction = new HashSet<RoleFunction>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<RoleFunction> RoleFunction { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
