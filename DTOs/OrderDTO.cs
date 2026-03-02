using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    //public record OrderDTO
    //(
    //    int OrderId ,

    //    DateOnly? OrderDate ,

    //     double OrderSum,

    //     int UserId 


    //);
    public record OrderDTO(
    int OrderId,
        DateOnly OrderDate,
        int Status,
        int UserId,
        string ShippingMethod,
        double TotalPrice,
        List<OrderItemDTO> Items
);
}