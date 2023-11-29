using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Params
{
    public class BaseParam
    {
    }
    public class ItemParam
    {
        [Required]
        public Guid id { get; set; }
    }
}
