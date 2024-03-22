using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Domain.Entities
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Quantity { get; set; }

        public float? Price { get; set; }
        public float? Total { get; set; }

        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }


        [ForeignKey("OrderId")]
        public Order? Orders { get; set; }

        [ForeignKey("ProductId")]
        public Product? Products { get; set; }
    }
}
