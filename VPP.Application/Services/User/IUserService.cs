using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.User
{

    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto Get(Guid id);
        bool Add(UserDto userDto);
        bool Update(UserDto userDto);
        bool Delete(Guid id);  

    }
}
