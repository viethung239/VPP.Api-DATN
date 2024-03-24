using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.WareHouseDetail
{
    public interface IWareHouseDetailService
    {
        List<WareHouseDetailDto> GetAll();
        WareHouseDetailDto Get(Guid id);
        bool Add(WareHouseDetailDto whdDto);
        bool Update(WareHouseDetailDto whdDto);
        bool Delete(Guid id);
    }
}
