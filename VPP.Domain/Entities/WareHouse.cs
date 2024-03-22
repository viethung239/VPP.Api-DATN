﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPP.Domain.Entities
{
    public class WareHouse
    {
        public Guid WareHouseId { get; set; }
        public string? WareHouseName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        //
        public ICollection<WareHouseDetail>? WareHouseDetails { get; set; }
    }
}
