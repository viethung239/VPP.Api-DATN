using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Application.Dto
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }
        public Guid? CategoryGroupId { get; set; }
        public string? CategoryName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
