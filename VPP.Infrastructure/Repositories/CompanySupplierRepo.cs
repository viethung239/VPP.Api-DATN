using Microsoft.Extensions.Logging;
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
    public class CompanySupplierRepo : Repo<CompanySupplier>, ICompanySupplierRepo
    {
        public CompanySupplierRepo(VPPDBContext dBContext, ILogger<Repo<CompanySupplier>> logger) : base(dBContext, logger) { }
    }
    
}
