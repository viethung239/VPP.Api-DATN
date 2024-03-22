using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VPP.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Avartar { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Comune { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public DateTime? BirthDay { get; set; }
        public int? Gender { get; set; }
        public bool? IsAdmin { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
       
      

        //
        public ICollection<UserRole>? UserRoles { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Order>? Orders { get; set; }
        //

    }
}
