using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Repositories;
using VPP.Infrastructure.Repositories;

namespace VPP.Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public List<ProductDto> GetAll()
        {
            return _mapper.Map<List<ProductDto>>(_productRepo.GetAll());
        }

        public ProductDto Get(Guid id)
        {
            return _mapper.Map<ProductDto>(_productRepo.Get(id));
        }

        public bool Add(ProductDto productDto)
        {
            return _productRepo.Add(_mapper.Map<VPP.Domain.Entities.Product>(productDto));
        }

        public bool Update(ProductDto productDto)
        {
            return _productRepo.Update(_mapper.Map<VPP.Domain.Entities.Product>(productDto));
        }

        public bool Delete(Guid id)
        {
            return _productRepo.Delete(id);
        }
    }
}
