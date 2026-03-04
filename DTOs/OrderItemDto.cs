using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OrderItemDTO
    {
        public int OrderId { get; set; }


        public int Quantity { get; set; }


        public string ProductName { get; set; }


        public double Price { get; set; }   // הוספנו מחיר


        public string Image { get; set; }   // הוספנו תמונה


        public double Size { get; set; }

        public OrderItemDTO() { } 
    }


}
