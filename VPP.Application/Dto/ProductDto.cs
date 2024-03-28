using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Application.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public Guid? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public float? ProductPrice { get; set; }
        public string? SDescription { get; set; }
        public string? LDescription { get; set; }
        public string? ProductImage { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    
    }
}
