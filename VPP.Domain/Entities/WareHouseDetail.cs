using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Domain.Entities
{
    public class WareHouseDetail
    {
        public Guid WareHouseDetailId { get; set; }
        public Guid? WareHouseId { get; set; }     
        public Guid? ProductId { get; set; }
        public Guid? SupplierId { get; set; }
        public float? Quantity { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        //
        [ForeignKey("WareHouseId")]
        public WareHouse? WareHouses { get; set; }

        [ForeignKey("ProductId")]
        public Product? Products { get; set; }

        [ForeignKey("SupplierId")]
        public CompanySupplier? CompanySuppliers { get; set; }
    }
}
