using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Repositories;

namespace VPP.Application.Services.WareHouse
{
    public class WareHouseService : IWareHouseService
    {
        private readonly IWareHouseRepo _whRepo;
        private readonly IMapper _mapper;
        public WareHouseService(IWareHouseRepo whRepo, IMapper mapper)
        {
            _whRepo = whRepo;
            _mapper = mapper;
        }
        public List<WareHouseDto> GetAll()
        {
            return _mapper.Map<List<WareHouseDto>>(_whRepo.GetAll());
        }

        public WareHouseDto Get(Guid id)
        {
            return _mapper.Map<WareHouseDto>(_whRepo.Get(id));
        }

        public bool Add(WareHouseDto whDto)
        {
            return _whRepo.Add(_mapper.Map<VPP.Domain.Entities.WareHouse>(whDto));
        }

        public bool Update(WareHouseDto whDto)
        {
            return _whRepo.Update(_mapper.Map<VPP.Domain.Entities.WareHouse>(whDto));
        }

        public bool Delete(Guid id)
        {
            return _whRepo.Delete(id);
        }
    }
}
