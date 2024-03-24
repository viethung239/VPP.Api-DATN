using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.OrderDetail
{
    public interface IOrderDetailService
    {
        List<OrderDetailDto> GetAll();
        OrderDetailDto Get(Guid id);
        bool Add(OrderDetailDto orderdetailDto);
        bool Update(OrderDetailDto orderdetailDto);
        bool Delete(Guid id);
    }
}
