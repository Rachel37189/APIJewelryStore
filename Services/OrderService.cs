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
        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            // 1. שליפת כל הישויות מה-Repository
            var orders = await _orderRepository.GetAllOrders(); // את צריכה להוסיף את זה ב-Repository (ראי מטה)

            // 2. המרה של רשימת הישויות לרשימה של DTOs בעזרת AutoMapper
            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

            return ordersDto;
        }
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

        public async Task<bool> UpdateStatus(int id, int status)
        {
            return await _orderRepository.UpdateOrderStatus(id, status);
        }


    }
}
