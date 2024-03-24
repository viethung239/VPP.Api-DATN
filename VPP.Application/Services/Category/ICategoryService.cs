using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.Category
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDto Get(Guid id);
        bool Add(CategoryDto categoryDto);
        bool Update(CategoryDto categoryDto);
        bool Delete(Guid id);
    }
}
