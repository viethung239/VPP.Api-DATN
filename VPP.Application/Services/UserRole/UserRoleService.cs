using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Application.Services.User;
using VPP.Domain.Repositories;
using VPP.Infrastructure.Context;
using VPP.Infrastructure.Repositories;

namespace VPP.Application.Services.UserRole
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepo _urRepo;
        private readonly IMapper _mapper;
        private readonly VPPDBContext _dbContext;
        public UserRoleService(IUserRoleRepo urRepo, IMapper mapper, VPPDBContext dbContext)
        {
            _urRepo = urRepo;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<UserRoleDto> GetRolesByUserId(Guid userId)
        {
            return _mapper.Map<List<UserRoleDto>>(_urRepo.GetAll().Where(ur => ur.UserId == userId));
        }


        public List<UserRoleDto> GetAll()
        {
            return _mapper.Map<List<UserRoleDto>>(_urRepo.GetAll());
        }

        public UserRoleDto Get(Guid id)
        {
            return _mapper.Map<UserRoleDto>(_urRepo.Get(id));
        }

        public bool Add(UserRoleDto userDto)
        {
            return _urRepo.Add(_mapper.Map<VPP.Domain.Entities.UserRole>(userDto));
        }

        public bool Update(UserRoleDto userDto)
        {
            return _urRepo.Update(_mapper.Map<VPP.Domain.Entities.UserRole>(userDto));
        }

        public bool Delete(Guid id)
        {
            return _urRepo.Delete(id);
        }

    }
}
