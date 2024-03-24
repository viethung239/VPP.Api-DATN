using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Repositories;

namespace VPP.Application.Services.CategoryGroup
{
    public class CategoryGroupService : ICategoryGroupService
    {
        private readonly ICategoryGroupRepo _categorygroupRepo;
        private readonly IMapper _mapper;
        public CategoryGroupService(ICategoryGroupRepo categorygroupRepo, IMapper mapper)
        {
            _categorygroupRepo = categorygroupRepo;
            _mapper = mapper;
        }
        public List<CategoryGroupDto> GetAll()
        {
            return _mapper.Map<List<CategoryGroupDto>>(_categorygroupRepo.GetAll());
        }

        public CategoryGroupDto Get(Guid id)
        {
            return _mapper.Map<CategoryGroupDto>(_categorygroupRepo.Get(id));
        }

        public bool Add(CategoryGroupDto categorygroupDto)
        {
            return _categorygroupRepo.Add(_mapper.Map<VPP.Domain.Entities.CategoryGroup>(categorygroupDto));
        }

        public bool Update(CategoryGroupDto categorygroupDto)
        {
            return _categorygroupRepo.Update(_mapper.Map<VPP.Domain.Entities.CategoryGroup>(categorygroupDto));
        }

        public bool Delete(Guid id)
        {
            return _categorygroupRepo.Delete(id);
        }
    }
}
