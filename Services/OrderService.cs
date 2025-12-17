using AutoMapper;
using DTOs;
using Entities;
using FluentNHibernate.Automapping;
using Repository;
namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
       // AutoMapper _mapper;
        IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;

        }
        public async Task<OrderDto> GetOrderById(int id)
        {
            Order order = await _orderRepository.GetOrderById(id);
            OrderDto orderDto = _mapper.Map<OrderDto>(order);
            return orderDto;
        }
        public async Task<OrderDto> addOrder(Order order)
        {
            Order order2 = await _orderRepository.addOrder(order);
            OrderDto orderDto = _mapper.Map<OrderDto>(order2);
            return orderDto;
        }

    }
}
