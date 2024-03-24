using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Repositories;

namespace VPP.Application.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepo orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }
        public List<OrderDto> GetAll()
        {
            return _mapper.Map<List<OrderDto>>(_orderRepo.GetAll());
        }

        public OrderDto Get(Guid id)
        {
            return _mapper.Map<OrderDto>(_orderRepo.Get(id));
        }

        public bool Add(OrderDto orderDto)
        {
            return _orderRepo.Add(_mapper.Map<VPP.Domain.Entities.Order>(orderDto));
        }

        public bool Update(OrderDto orderDto)
        {
            return _orderRepo.Update(_mapper.Map<VPP.Domain.Entities.Order>(orderDto));
        }

        public bool Delete(Guid id)
        {
            return _orderRepo.Delete(id);
        }
    }
}
