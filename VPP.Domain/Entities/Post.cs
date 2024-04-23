using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Domain.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public Guid? UserId { get; set; }
        public string? PostName { get; set; }
        public string? PostImg {  get; set; }
        public string? SContent { get; set; }
        public string? LContent { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsHot { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        //

        //
        [ForeignKey("UserId")]
        public User? Users { get; set; }
    }
}
