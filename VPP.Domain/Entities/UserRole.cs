using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Domain.Entities
{
    public class UserRole
    {

        public Guid UserRoleId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? RoleId { get; set; } 

        //
        //
        [ForeignKey("RoleId")]
        public Role? Roles { get; set; }

        [ForeignKey("UserId")]
        public User? Users { get; set; }
    }
}
