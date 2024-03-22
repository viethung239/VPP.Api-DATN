using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Domain.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid? UserId { get; set; }
        public float? TotalAmount { get; set; }
        public string? OrderCode { get; set; }
        public int? PaymentType { get; set; }
        public int? Status { get; set; }
        public string? Note { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        //
        [ForeignKey("UserId")]
        public User? Users { get; set; }
        //

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
