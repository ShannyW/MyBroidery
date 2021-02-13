using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBroidery.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get;set;}
        public string Password { get; set; }
        public ICollection<UserRole> Roles { get; set; }
        public bool HasPrivilege(string privilege)
        {
            return Roles.SelectMany(r => r.Role.Privileges).Any(r=>r.Privilege==privilege);
        }

    }
}
