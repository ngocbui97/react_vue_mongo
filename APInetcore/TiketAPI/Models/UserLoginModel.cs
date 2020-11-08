using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketAPI.Models
{
    [Serializable]
    public class UserLoginModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Active { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
