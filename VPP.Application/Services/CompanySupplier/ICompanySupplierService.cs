using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.CompanySupplier
{
    public interface ICompanySupplierService
    {
        List<CompanySupplierDto> GetAll();  
        CompanySupplierDto Get(Guid id);
        bool Add(CompanySupplierDto cplDto);
        bool Update(CompanySupplierDto cplDto);
        bool Delete(Guid id);
    }
}
