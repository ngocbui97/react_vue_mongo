using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.EF
{
    [Table("Function")]
    public partial class Function
    {
        public Function()
        {
            RoleFunction = new HashSet<RoleFunction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<RoleFunction> RoleFunction { get; set; }
    }
}
