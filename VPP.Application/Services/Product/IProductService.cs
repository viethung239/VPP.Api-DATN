using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.Product
{
    public interface IProductService
    {
        List<ProductDto> GetAll();
        ProductDto Get(Guid id);
        bool Add(ProductDto productDto);
        bool Update(ProductDto productDto);
        bool Delete(Guid id);
    }
}
