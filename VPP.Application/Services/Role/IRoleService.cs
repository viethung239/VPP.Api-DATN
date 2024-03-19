using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto.User;

namespace VPP.Application.Services.Role
{
    public interface IRoleService
    {
        List<RoleDto> GetAll();
        RoleDto Get(Guid id);
        bool Add(RoleDto roleDto);
        bool Update(RoleDto roleDto);
        bool Delete(Guid id);
    }
}
