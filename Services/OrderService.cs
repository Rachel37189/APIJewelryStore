using AutoMapper;
using DTOs;
using Entities;
using Repository;
namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
             _mapper=mapper;
        }
        //public async Task<OrderDTO> GetOrderById(int id)
        //{
        //    //return await _orderRepository.GetOrderById(id);
        //    Order order = await _orderRepository.GetOrderById(id);
        //    OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
        //    return orderDTO;
        //}
        public async Task<OrderDTO?> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order == null) return null;

            return new OrderDTO(
                order.OrderId,
                order.OrderDate,
                order.Status,
                order.UserId,
                (order.ShippingMethod ?? "").Trim(),
                order.TotalPrice,
                order.OrderItems.Select(oi => new OrderItemDTO(
                    oi.ProductId,
                    oi.Quantity,
                    (float)oi.Size,
                    (float)oi.PriceAtPurchase
                )).ToList()
            );
        }
        public async Task<OrderDTO> addOrder(OrderDTO order)
        {
           // Order order2 = await _orderRepository.addOrder(order);
           Order order2 = await _orderRepository.addOrder(_mapper.Map<OrderDTO, Order>(order));
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order2);
            return orderDTO;
        }
        public async Task<OrderDTO> CreateOrderAsync(OrderCreateDTO dto)
        {
            // בדיקות מינימום
            if (dto.Items == null || dto.Items.Count == 0)
                throw new Exception("העגלה ריקה - לא ניתן לבצע הזמנה");

            var shippingMethod = (dto.ShippingMethod ?? "").Trim();
            if (shippingMethod != "משלוח עד הבית" && shippingMethod != "איסוף מהסניף הקרוב")
                throw new Exception("שיטת משלוח לא תקינה");

            var userExists = await _orderRepository.UserExistsAsync(dto.UserId);
            if (!userExists)
                throw new Exception("המשתמש לא רשום במערכת");

            // שליפת מחירים מה-DB
            var productIds = dto.Items.Select(i => i.ProductId).Distinct().ToList();
            var priceMap = await _orderRepository.GetProductPricesAsync(productIds);

            // אם חסר מוצר:
            if (priceMap.Count != productIds.Count)
                throw new Exception("אחד או יותר מהמוצרים לא קיימים");

            // חישוב סכום פריטים
            double itemsSum = 0;
            foreach (var it in dto.Items)
            {
                if (it.Quantity <= 0)
                    throw new Exception("כמות לא תקינה באחד הפריטים");

                itemsSum += priceMap[it.ProductId] * it.Quantity;
            }

            // משלוח: 30 רק אם משלוח עד הבית וגם פחות מ-250
            double shippingPrice = 0;
            if (shippingMethod == "משלוח עד הבית" && itemsSum < 250)
                shippingPrice = 30;

            double total = itemsSum + shippingPrice;

            // בניית Order + Items
            var order = new Order
            {
                UserId = dto.UserId,
                OrderDate = DateOnly.FromDateTime(DateTime.Now),
                Status = 1,
                ShippingMethod = shippingMethod,
                TotalPrice = total
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

            // שמירה DB (Order + Items יחד)
            var saved = await _orderRepository.AddOrderWithItemsAsync(order);

            // החזרת OrderDTO מלא
            return new OrderDTO(
                saved.OrderId,
                saved.OrderDate,
                saved.Status,
                saved.UserId,
                saved.ShippingMethod.Trim(),
                saved.TotalPrice,
                saved.OrderItems.Select(oi => new OrderItemDTO(
                    oi.ProductId,
                    oi.Quantity,
                    (float)oi.Size,
                    (float)oi.PriceAtPurchase
                )).ToList()
            );
        }
    }
}
    

