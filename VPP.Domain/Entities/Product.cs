using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public string? ProductName { get; set; }
        public float? ProductPrice { get; set; }
        public string? SDescription { get; set; }
        public string? LDescription { get; set; }
        public string? ProductImage { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        //
        [ForeignKey("CategoryId")]
        public Category? Categorys { get; set; }
        //
        public ICollection<WareHouseDetail>? WareHouseDetails { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }

    }
}
