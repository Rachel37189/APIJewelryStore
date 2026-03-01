
using AutoMapper;
using DTOs;
using Entities;
using NHibernate.Mapping.ByCode.Impl;
using Repository;

namespace Services
{
    public class AutoMapper :Profile
    {       
       public AutoMapper() {

      

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            // מיפוי מידות - חשוב מאוד ל-POST ו-GET
            CreateMap<WebApiShop.Entities.Size, SizeDTO>().ReverseMap();

            // מיפוי מוצר - הפשוט ביותר
            // בזכות ה-Include(p => p.Sizes) ברפוזיטורי,
            // AutoMapper יזהה לבד את רשימת המידות וימפה אותה
            CreateMap<Product, ProductCreateDTO>().ReverseMap();

            // אם יש לך גם productDto (באות קטנה), תשאירי אותו:
            CreateMap<Product, productDto>().ReverseMap();
        }
    }
}



