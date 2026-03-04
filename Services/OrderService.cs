//using AutoMapper;
//using DTOs;
//using Entities;
//<<<<<<< HEAD
//=======
//using FluentNHibernate.Automapping;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//using Repository;
//namespace Services
//{
//    public class OrderService : IOrderService
//    {
//        IOrderRepository _orderRepository;
//<<<<<<< HEAD
//        IMapper _mapper;
//        public OrderService(IOrderRepository orderRepository, IMapper mapper)
//        {
//            _orderRepository = orderRepository;
//             _mapper=mapper;
//        }
//        //public async Task<OrderDTO> GetOrderById(int id)
//        //{
//        //    //return await _orderRepository.GetOrderById(id);
//        //    Order order = await _orderRepository.GetOrderById(id);
//        //    OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
//        //    return orderDTO;
//        //}
//        public async Task<OrderDTO?> GetOrderById(int id)
//        {
//            var order = await _orderRepository.GetOrderById(id);
//            if (order == null) return null;

//            return new OrderDTO(
//                order.OrderId,
//                order.OrderDate,
//                order.Status,
//                order.UserId,
//                (order.ShippingMethod ?? "").Trim(),
//                order.TotalPrice,
//                order.OrderItems.Select(oi => new OrderItemDTO(
//                    oi.ProductId,
//                    oi.Quantity,
//                    (float)oi.Size,
//                    (float)oi.PriceAtPurchase
//                )).ToList()
//            );
//        }
//        public async Task<OrderDTO> addOrder(OrderDTO order)
//        {
//           // Order order2 = await _orderRepository.addOrder(order);
//           Order order2 = await _orderRepository.addOrder(_mapper.Map<OrderDTO, Order>(order));
//            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order2);
//            return orderDTO;
//        }
//        public async Task<OrderDTO> CreateOrderAsync(OrderCreateDTO dto)
//        {
//            // בדיקות מינימום
//            if (dto.Items == null || dto.Items.Count == 0)
//                throw new Exception("העגלה ריקה - לא ניתן לבצע הזמנה");

//            var shippingMethod = (dto.ShippingMethod ?? "").Trim();
//            if (shippingMethod != "משלוח עד הבית" && shippingMethod != "איסוף מהסניף הקרוב")
//                throw new Exception("שיטת משלוח לא תקינה");

//            var userExists = await _orderRepository.UserExistsAsync(dto.UserId);
//            if (!userExists)
//                throw new Exception("המשתמש לא רשום במערכת");

//            // שליפת מחירים מה-DB
//            var productIds = dto.Items.Select(i => i.ProductId).Distinct().ToList();
//            var priceMap = await _orderRepository.GetProductPricesAsync(productIds);

//            // אם חסר מוצר:
//            if (priceMap.Count != productIds.Count)
//                throw new Exception("אחד או יותר מהמוצרים לא קיימים");

//            // חישוב סכום פריטים
//            double itemsSum = 0;
//            foreach (var it in dto.Items)
//            {
//                if (it.Quantity <= 0)
//                    throw new Exception("כמות לא תקינה באחד הפריטים");

//                itemsSum += priceMap[it.ProductId] * it.Quantity;
//            }

//            // משלוח: 30 רק אם משלוח עד הבית וגם פחות מ-250
//            double shippingPrice = 0;
//            if (shippingMethod == "משלוח עד הבית" && itemsSum < 250)
//                shippingPrice = 30;

//            double total = itemsSum + shippingPrice;

//            // בניית Order + Items
//            var order = new Order
//            {
//                UserId = dto.UserId,
//                OrderDate = DateOnly.FromDateTime(DateTime.Now),
//                Status = 1,
//                ShippingMethod = shippingMethod,
//                TotalPrice = total
//            };

//            foreach (var it in dto.Items)
//            {
//                order.OrderItems.Add(new OrderItem
//                {
//                    ProductId = it.ProductId,
//                    Quantity = it.Quantity,
//                    Size = it.Size,
//                    PriceAtPurchase = priceMap[it.ProductId]
//                });
//            }

//            // שמירה DB (Order + Items יחד)
//            var saved = await _orderRepository.AddOrderWithItemsAsync(order);

//            // החזרת OrderDTO מלא
//            return new OrderDTO(
//                saved.OrderId,
//                saved.OrderDate,
//                saved.Status,
//                saved.UserId,
//                saved.ShippingMethod.Trim(),
//                saved.TotalPrice,
//                saved.OrderItems.Select(oi => new OrderItemDTO(
//                    oi.ProductId,
//                    oi.Quantity,
//                    (float)oi.Size,
//                    (float)oi.PriceAtPurchase
//                )).ToList()
//            );
//        }
//    }
//}


//=======
//       // AutoMapper _mapper;
//        IMapper _mapper;
//        public async Task<IEnumerable<OrderDto>> GetAllOrders()
//        {
//            // 1. שליפת כל הישויות מה-Repository
//            var orders = await _orderRepository.GetAllOrders(); // את צריכה להוסיף את זה ב-Repository (ראי מטה)

//            // 2. המרה של רשימת הישויות לרשימה של DTOs בעזרת AutoMapper
//            var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);

//            return ordersDto;
//        }
//        public OrderService(IOrderRepository orderRepository, IMapper mapper)
//        {
//            _orderRepository = orderRepository;
//            _mapper = mapper;

//        }
//        public async Task<OrderDto> GetOrderById(int id)
//        {
//            Order order = await _orderRepository.GetOrderById(id);
//            OrderDto orderDto = _mapper.Map<OrderDto>(order);
//            return orderDto;
//        }
//        public async Task<OrderDto> addOrder(Order order)
//        {
//            Order order2 = await _orderRepository.addOrder(order);
//            OrderDto orderDto = _mapper.Map<OrderDto>(order2);
//            return orderDto;
//        }

//        public async Task<bool> UpdateStatus(int id, int status)
//        {
//            return await _orderRepository.UpdateOrderStatus(id, status);
//        }

//        //public async Task<List<Order>> GetOrdersByUserId(int userId)
//        //{
//        //    return await _orderRepository.GetOrdersByUserId(userId);
//        //}

//        public async Task<IEnumerable<OrderDto>> GetOrdersByUserId(int userId)
//        {
//            // שליפה מה-Repository (שימי לב שצריך להוסיף את הפונקציה גם שם)
//            var orders = await _orderRepository.GetOrdersByUserId(userId);

//            // מיפוי לרשימת DTOs
//            return _mapper.Map<IEnumerable<OrderDto>>(orders);
//        }
//    }
//}
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca


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
    }

   
}