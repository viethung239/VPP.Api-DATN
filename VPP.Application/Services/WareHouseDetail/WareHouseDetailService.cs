using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Repositories;

namespace VPP.Application.Services.WareHouseDetail
{
    public class WareHouseDetailService : IWareHouseDetailService
    {
        private readonly IWareHouseDetailRepo _whdRepo;
        private readonly IMapper _mapper;
        public WareHouseDetailService(IWareHouseDetailRepo whdRepo, IMapper mapper)
        {
            _whdRepo = whdRepo;
            _mapper = mapper;
        }
        public List<WareHouseDetailDto> GetAll()
        {
            return _mapper.Map<List<WareHouseDetailDto>>(_whdRepo.GetAll());
        }

        public WareHouseDetailDto Get(Guid id)
        {
            return _mapper.Map<WareHouseDetailDto>(_whdRepo.Get(id));
        }

        public bool Add(WareHouseDetailDto whdDto)
        {
            return _whdRepo.Add(_mapper.Map<VPP.Domain.Entities.WareHouseDetail>(whdDto));
        }

        public bool Update(WareHouseDetailDto whdDto)
        {
            return _whdRepo.Update(_mapper.Map<VPP.Domain.Entities.WareHouseDetail>(whdDto));
        }

        public bool Delete(Guid id)
        {
            return _whdRepo.Delete(id);
        }
    }
}
