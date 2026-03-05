//<<<<<<< HEAD
//﻿using Entities;
//using DTOs;
//=======
//﻿using DTOs;
//using Entities;

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//namespace Services
//{
//    public interface IProductService
//    {
//<<<<<<< HEAD

//            Task<List<ProductDTO>> GetProductsAsync(
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
//        Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto);
//        Task<ProductDetailsDto?> GetProductDetailsAsync(int id);
//=======
//        //Task<List<productDto>> GetProducts(int? pId, string? name, int position, int skip, float? minPrice, float? maxPrice, string? desc, int?[] categoryIds);
//        Task<List<ProductCreateDTO>> GetProductsAsync(
//        int? categoryId, string? color, float? minPrice, float? maxPrice,
//        bool? justOnline, bool? isClassic, bool? isTrendy, bool? isPearls,
//        bool? isStudio, string? sortMode);
//        Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto);   
//        Task UpdateProductAsync(int id, ProductCreateDTO dto);
//        Task DeleteProductAsync(int id);
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}


//using DTOs;

//public interface IProductService
//{
//    Task<List<ProductCreateDTO>> GetProductsAsync(int? categoryId, string? color, float? minPrice, float? maxPrice, bool? justOnline, bool? isClassic, bool? isTrendy, bool? isPearls, bool? isStudio, string? sortMode);
//    Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto);
//    Task<ProductDetailsDTO?> GetProductDetailsAsync(int id); Task UpdateProductAsync(int id, ProductCreateDTO dto);
//    Task DeleteProductAsync(int id);

//    Task UpdateProductAsync(int id, ProductCreateDTO dto);
//}


using DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductService
{
    Task<List<ProductCreateDTO>> GetProductsAsync(int? categoryId, string? color, float? minPrice, float? maxPrice, bool? justOnline, bool? isClassic, bool? isTrendy, bool? isPearls, bool? isStudio, string? sortMode);

    Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto);

    Task<ProductDetailsDTO?> GetProductDetailsAsync(int id);

    Task UpdateProductAsync(int id, ProductCreateDTO dto);

    Task DeleteProductAsync(int id);
}