﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Domain.Entities;
using VPP.Domain.Repositories;
using VPP.Infrastructure.Context;

namespace VPP.Infrastructure.Repositories
{
    public class CategoryGroupRepo : Repo<CategoryGroup>, ICategoryGroupRepo
    {
        public CategoryGroupRepo(VPPDBContext dBContext, ILogger<Repo<CategoryGroup>> logger) : base(dBContext, logger) { }
    }
    
}
