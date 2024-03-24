using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPP.Application.Dto;
using VPP.Domain.Repositories;

namespace VPP.Application.Services.OrderDetail
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepo _orderdetailRepo;
        private readonly IMapper _mapper;
        public OrderDetailService(IOrderDetailRepo orderdetailRepo, IMapper mapper)
        {
            _orderdetailRepo = orderdetailRepo;
            _mapper = mapper;
        }
        public List<OrderDetailDto> GetAll()
        {
            return _mapper.Map<List<OrderDetailDto>>(_orderdetailRepo.GetAll());
        }

        public OrderDetailDto Get(Guid id)
        {
            return _mapper.Map<OrderDetailDto>(_orderdetailRepo.Get(id));
        }

        public bool Add(OrderDetailDto orderdetailDto)
        {
            return _orderdetailRepo.Add(_mapper.Map<VPP.Domain.Entities.OrderDetail>(orderdetailDto));
        }

        public bool Update(OrderDetailDto orderdetailDto)
        {
            return _orderdetailRepo.Update(_mapper.Map<VPP.Domain.Entities.OrderDetail>(orderdetailDto));
        }

        public bool Delete(Guid id)
        {
            return _orderdetailRepo.Delete(id);
        }
    }
}
