using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.WareHouse
{
    public interface IWareHouseService
    {
        List<WareHouseDto> GetAll();
        WareHouseDto Get(Guid id);
        bool Add(WareHouseDto whDto);
        bool Update(WareHouseDto whDto);
        bool Delete(Guid id);
    }
}
