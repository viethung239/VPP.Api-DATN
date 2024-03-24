using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;

namespace VPP.Application.Services.Order
{
    public interface IOrderService
    {
        List<OrderDto> GetAll();
        OrderDto Get(Guid id);
        bool Add(OrderDto orderDto);
        bool Update(OrderDto orderDto);
        bool Delete(Guid id);
    }
}
