

using AutoMapper;
using DTOs;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByUserId(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserId(userId);
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO?> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order == null) return null;
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<bool> UpdateStatus(int id, int status)
        {
            return await _orderRepository.UpdateOrderStatus(id, status);
        }

        // לוגיקת יצירת הזמנה מורכבת (הגרסה שלך)
        public async Task<OrderDTO> CreateOrderAsync(OrderCreateDTO dto)
        {
            if (dto.Items == null || dto.Items.Count == 0)
                throw new Exception("העגלה ריקה - לא ניתן לבצע הזמנה");

            var shippingMethod = (dto.ShippingMethod ?? "").Trim();
            if (shippingMethod != "משלוח עד הבית" && shippingMethod != "איסוף מהסניף הקרוב")
                throw new Exception("שיטת משלוח לא תקינה");

            var userExists = await _orderRepository.UserExistsAsync(dto.UserId);
            if (!userExists)
                throw new Exception("המשתמש לא רשום במערכת");

            var productIds = dto.Items.Select(i => i.ProductId).Distinct().ToList();
            var priceMap = await _orderRepository.GetProductPricesAsync(productIds);

            if (priceMap.Count != productIds.Count)
                throw new Exception("אחד או יותר מהמוצרים לא קיימים");

            double itemsSum = 0;
            foreach (var it in dto.Items)
            {
                if (it.Quantity <= 0)
                    throw new Exception("כמות לא תקינה באחד הפריטים");
                itemsSum += priceMap[it.ProductId] * it.Quantity;
            }

            double shippingPrice = 0;
            if (shippingMethod == "משלוח עד הבית" && itemsSum < 250)
                shippingPrice = 30;

            double total = itemsSum + shippingPrice;

            var order = new Order
            {
                UserId = dto.UserId,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                Status = 1,
                ShippingMethod = shippingMethod,
                TotalPrice = total,
                OrderItems = new List<OrderItem>()
            };

            foreach (var it in dto.Items)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = it.ProductId,
                    Quantity = it.Quantity,
                    Size = it.Size,
                    PriceAtPurchase = priceMap[it.ProductId]
                });
            }

            var saved = await _orderRepository.AddOrderWithItemsAsync(order);
            return _mapper.Map<OrderDTO>(saved);
        }


        public async Task<bool> MarkAsDelivered(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order == null) return false;

            // בדיקה: ניתן לעדכן לנמסר (4) רק אם הסטטוס הנוכחי הוא נשלח (3) 
            // ושהוא לא כבר בסטטוס נמסר
            if (order.Status == 3)
            {
                return await _orderRepository.UpdateOrderStatus(id, 4);
            }
            return false;
        }
    }

   
}