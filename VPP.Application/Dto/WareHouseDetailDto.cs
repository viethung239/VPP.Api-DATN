using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Application.Dto
{
    public class WareHouseDetailDto
    {
        public Guid WareHouseDetailId { get; set; }
        public Guid? WareHouseId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? SupplierId { get; set; }
        public float? Quantity { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
