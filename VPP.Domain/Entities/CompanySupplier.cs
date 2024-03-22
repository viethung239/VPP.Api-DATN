using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Domain.Entities
{
    public class CompanySupplier
    {
        public Guid SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? Phone{ get; set; }
        public string? Address { get; set; }
        public string? Comune { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        //
        public ICollection<WareHouseDetail>? WareHouseDetails { get; set; }
    }
}
