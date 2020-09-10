using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.EF
{
    [Table("Role_function")]
    public partial class RoleFunction
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int FunctionId { get; set; }
        public bool Active { get; set; }

        public virtual Function Function { get; set; }
        public virtual Role Role { get; set; }
    }
}
