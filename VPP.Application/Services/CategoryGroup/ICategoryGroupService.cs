using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.CategoryGroup
{
    public interface ICategoryGroupService
    {
        List<CategoryGroupDto> GetAll();
        CategoryGroupDto Get(Guid id);
        bool Add(CategoryGroupDto categorygroupDto);
        bool Update(CategoryGroupDto categorygroupDto);
        bool Delete(Guid id);
    }
}
