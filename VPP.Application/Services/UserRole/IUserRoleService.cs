using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.UserRole
{
    public interface IUserRoleService
    {
        List<UserRoleDto> GetAll();
        UserRoleDto Get(Guid id);
        bool Add(UserRoleDto urDto);
        bool Update(UserRoleDto urDto);
        bool Delete(Guid id);


        List<UserRoleDto> GetRolesByUserId(Guid userId);
    }
}
