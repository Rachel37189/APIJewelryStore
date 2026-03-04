//<<<<<<< HEAD
//﻿using Entities;
//using DTOs;
//=======
//﻿using DTOs;
//using Entities;

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//namespace Services
//{
//    public interface IOrderService
//    {
//<<<<<<< HEAD
//        Task<OrderDTO> addOrder(OrderDTO order);
//        Task<OrderDTO> CreateOrderAsync(OrderCreateDTO dto);
//        Task<OrderDTO> GetOrderById(int id);
//=======
//        Task<OrderDto> addOrder(Order order);
//        Task<OrderDto> GetOrderById(int id);

//        Task<bool> UpdateStatus(int id, int status);
//        Task<IEnumerable<OrderDto>> GetAllOrders();

//        Task<IEnumerable<OrderDto>> GetOrdersByUserId(int userId);
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }


//}


using DTOs;

public interface IOrderService
{
    Task<IEnumerable<OrderDTO>> GetAllOrders();
    Task<IEnumerable<OrderDTO>> GetOrdersByUserId(int userId);
    Task<OrderDTO?> GetOrderById(int id);
    Task<bool> UpdateStatus(int id, int status);
    Task<OrderDTO> CreateOrderAsync(OrderCreateDTO dto);
}