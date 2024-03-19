using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto.User;
using VPP.Domain.Repositories;

namespace VPP.Application.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo; 
        private readonly IMapper _mapper;
        public RoleService(IRoleRepo roleRepo, IMapper mapper)
        {
            _roleRepo = roleRepo;
            _mapper = mapper;
        }
        public List<RoleDto> GetAll()
        {
            return _mapper.Map<List<RoleDto>>(_roleRepo.GetAll());
        }

        public RoleDto Get(Guid id)
        {
            return _mapper.Map<RoleDto>(_roleRepo.Get(id));
        }

        public bool Add(RoleDto roleDto)
        {
            return _roleRepo.Add(_mapper.Map<VPP.Domain.Entities.Role>(roleDto));
        }

        public bool Update(RoleDto roleDto)
        {
            return _roleRepo.Update(_mapper.Map<VPP.Domain.Entities.Role>(roleDto));
        }

        public bool Delete(Guid id)
        {
            return _roleRepo.Delete(id);
        }

    }
}
