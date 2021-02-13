using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBroidery.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RolePrivilege> Privileges { get; set; }
        public ICollection<UserRole> Users { get; set; }
    }
}
