//<<<<<<< HEAD
//﻿using AutoMapper;
//using DTOs;
//using Entities;

//namespace Services
//{
//    public class AutoMapper:Profile
//    {
//       public AutoMapper() { 

//            CreateMap<User,UserDTO>().ReverseMap();
//            CreateMap<Product,ProductDTO>().ReverseMap();
//            CreateMap<Product, ProductCreateDTO>().ReverseMap();
//            CreateMap<Order, OrderDTO>().ReverseMap();
//            CreateMap<Category, CategoryDTO>().ReverseMap();
//            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();

//       }
//    }
//}
//=======
//﻿
//using AutoMapper;
//using DTOs;
//using Entities;
//using NHibernate.Mapping.ByCode.Impl;
//using Repository;

//namespace Services
//{
//    public class AutoMapper :Profile
//    {       
//       public AutoMapper() {



//            //CreateMap<User, UserDto>().ReverseMap();
//            // בתוך ה-Constructor של ה-AutoMapper Profile
//            CreateMap<User, UserDto>()
//                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
//                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Email))
//                .ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(src => src.IsAdmin)) // הוספת המיפוי המפורש
//                .ReverseMap();
//            //CreateMap<Order, OrderDto>().ReverseMap();
//            CreateMap<Category, CategoryDto>().ReverseMap();
//            //CreateMap<OrderItem, OrderItemDto>().ReverseMap();
//            // בתוך ה-Constructor של AutoMapper Profile
//            CreateMap<OrderItem, OrderItemDto>()
//                 .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
//                 .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Product.Image1)) // לוקחים את התמונה הראשונה
//                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceAtPurchase)) // מחיר בעת הקנייה
//                 .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
//                 .ReverseMap();

//            //CreateMap<Order, OrderDto>()
//            //    .ForMember(dest => dest.OrderSum, opt => opt.MapFrom(src => src.TotalPrice)) // מיפוי מה-DB ל-DTO
//            //    .ReverseMap()
//            //    .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderSum));  // מיפוי מידות - חשוב מאוד ל-POST ו-GET
//            CreateMap<WebApiShop.Entities.Size, SizeDTO>().ReverseMap();

//            CreateMap<Order, OrderDto>()
//                .ForMember(dest => dest.OrderSum, opt => opt.MapFrom(src => src.TotalPrice));

//            CreateMap<OrderDto, Order>()
//                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderSum));

//            // מיפוי מוצר - הפשוט ביותר
//            // בזכות ה-Include(p => p.Sizes) ברפוזיטורי,
//            // AutoMapper יזהה לבד את רשימת המידות וימפה אותה
//            CreateMap<Product, ProductCreateDTO>().ReverseMap();
//            // בתוך הקונסטרקטור של AutoMapper.cs
//            CreateMap<UserUpdateDto, User>().ReverseMap();
//            // אם יש לך גם productDto (באות קטנה), תשאירי אותו:
//            CreateMap<Product, productDto>().ReverseMap();
//        }
//    }
//}



//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
using AutoMapper;
using DTOs;
using Entities;
using Repository;

namespace Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            // מיפוי משתמש - שימי לב לשמות השדות עבור האנגולר
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.IsAdmin, opt => opt.MapFrom(src => src.IsAdmin))
                .ReverseMap();

            //CreateMap<UserUpdateDTO, User>().ReverseMap();

            // מיפוי קטגוריה
            CreateMap<Category, CategoryDTO>().ReverseMap();

            // מיפוי פריטי הזמנה - קריטי להצגת נתוני מוצר בתוך הזמנה
            CreateMap<OrderItem, OrderItemDTO>()
                 .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                 .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Product.Image1))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PriceAtPurchase))
                 .ReverseMap();

            // מיפוי הזמנה - טיפול בסיכום ההזמנה
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.OrderSum, opt => opt.MapFrom(src => src.TotalPrice))
                .ReverseMap()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderSum));

            // מיפוי מוצרים
            CreateMap<Product, productDTO>().ReverseMap(); // הגרסה הישנה
            CreateMap<Product, productDTO>().ReverseMap(); // הגרסה החדשה (שימי לב לאותיות קטנות/גדולות ב-DTO)
            CreateMap<Product, ProductCreateDTO>().ReverseMap();

            // מיפוי מידות
            CreateMap<Size, SizeDTO>().ReverseMap();
        }
    }
}