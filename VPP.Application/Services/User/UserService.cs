using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Entities;
using VPP.Domain.Repositories;
using VPP.Infrastructure.Repositories;

namespace VPP.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo; 
        private readonly IMapper _mapper;
       
        private readonly IUserRoleRepo _urRepo;
        public UserService(IUserRepo userRepo, IUserRoleRepo urRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _urRepo = urRepo;
            _mapper = mapper;
            
        }
      

        public List<UserDto> GetAll()
        {
            return _mapper.Map<List<UserDto>>(_userRepo.GetAll());
        }

        public UserDto Get(Guid id)
        {
            return _mapper.Map<UserDto>(_userRepo.Get(id));
        }

        public bool Add(UserDto userDto)
        {
            return _userRepo.Add(_mapper.Map<VPP.Domain.Entities.User> (userDto));
        }

        public bool Update(UserDto userDto)
        {
            return _userRepo.Update(_mapper.Map<VPP.Domain.Entities.User>(userDto));
        }

        public bool Delete(Guid id)
        {
            return _userRepo.Delete(id);
        }
    }
}
