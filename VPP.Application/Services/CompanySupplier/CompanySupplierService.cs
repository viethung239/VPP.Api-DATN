using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Repositories;

namespace VPP.Application.Services.CompanySupplier
{
    public class CompanySupplierService : ICompanySupplierService
    {
        private readonly ICompanySupplierRepo _cplRepo;
        private readonly IMapper _mapper;
        public CompanySupplierService(ICompanySupplierRepo cplRepo, IMapper mapper)
        {
            _cplRepo = cplRepo;
            _mapper = mapper;
        }
        public List<CompanySupplierDto> GetAll()
        {
            return _mapper.Map<List<CompanySupplierDto>>(_cplRepo.GetAll());
        }

        public CompanySupplierDto Get(Guid id)
        {
            return _mapper.Map<CompanySupplierDto>(_cplRepo.Get(id));
        }

        public bool Add(CompanySupplierDto cplDto)
        {
            return _cplRepo.Add(_mapper.Map<VPP.Domain.Entities.CompanySupplier>(cplDto));
        }

        public bool Update(CompanySupplierDto cplDto)
        {
            return _cplRepo.Update(_mapper.Map<VPP.Domain.Entities.CompanySupplier>(cplDto));
        }

        public bool Delete(Guid id)
        {
            return _cplRepo.Delete(id);
        }
    }
}
