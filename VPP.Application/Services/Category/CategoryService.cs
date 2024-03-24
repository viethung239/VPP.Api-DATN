using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Repositories;
using VPP.Infrastructure.Repositories;

namespace VPP.Application.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public List<CategoryDto> GetAll()
        {
            return _mapper.Map<List<CategoryDto>>(_categoryRepo.GetAll());
        }

        public CategoryDto Get(Guid id)
        {
            return _mapper.Map<CategoryDto>(_categoryRepo.Get(id));
        }

        public bool Add(CategoryDto categoryDto)
        {
            return _categoryRepo.Add(_mapper.Map<VPP.Domain.Entities.Category>(categoryDto));
        }

        public bool Update(CategoryDto categoryDto)
        {
            return _categoryRepo.Update(_mapper.Map<VPP.Domain.Entities.Category>(categoryDto));
        }

        public bool Delete(Guid id)
        {
            return _categoryRepo.Delete(id);
        }
    }
}
