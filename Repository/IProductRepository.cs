//<<<<<<< HEAD
//﻿using Entities;
//=======
//﻿using DTOs;
//using Entities;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

//namespace Repository
//{
//    public interface IProductRepository
//    {
//<<<<<<< HEAD

//            Task<List<Product>> GetProductsAsync(
//                int? categoryId,
//                string? color,
//                float? minPrice,
//                float? maxPrice,
//                bool? justOnline,
//                bool? isClassic,
//                bool? isTrendy,
//                bool? isPearls,
//                bool? isStudio,
//                string? sortMode
//            );
//        //Task<Product> AddProduct(Product product);
//        Task<Product> AddProductAsync(Product product);
//        Task<Product?> GetByIdWithSizesAsync(int id);
//    }

//=======
//        Task<List<Product>> GetProductsAsync(
//                   int? categoryId, string? color, float? minPrice, float? maxPrice,
//                   bool? justOnline, bool? isClassic, bool? isTrendy, bool? isPearls,
//                   bool? isStudio, string? sortMode);
//        //Task<Product> AddProductAsync(Product product);
//        //Task UpdateProductAsync(int id, Product product);
//        Task<Product> AddProductAsync(Product product);

//        Task UpdateProductAsync(int id, Product product);
//        Task DeleteProductAsync(int id);

//    }
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//}


using DTOs;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync(
            int? categoryId,
            string? color,
            float? minPrice,
            float? maxPrice,
            bool? justOnline,
            bool? isClassic,
            bool? isTrendy,
            bool? isPearls,
            bool? isStudio,
            string? sortMode
        );

        Task<Product> AddProductAsync(Product product);

        Task<Product?> GetByIdWithSizesAsync(int id);

        Task UpdateProductAsync(int id, Product product);

        Task DeleteProductAsync(int id);
    }
}