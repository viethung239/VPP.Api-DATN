using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Application.Dto
{
    public class PostDto
    {
        public Guid PostId { get; set; }
        public Guid? UserId { get; set; }
        public string? PostName { get; set; }
        public string? PostImg { get; set; }
        public string? SContent { get; set; }
        public string? LContent { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
