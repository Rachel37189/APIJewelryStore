//<<<<<<< HEAD
//﻿using AutoMapper;
//using DTOs;
//using Entities;
//using Repository;
//using System.Security.Cryptography;
//=======
//﻿using Entities;
//using FluentNHibernate.Automapping;
//using FluentNHibernate.Testing.Values;
//using Repository;
//using System.Collections.Generic;
//using DTOs;
//using AutoMapper;
//using Microsoft.EntityFrameworkCore;

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//namespace Services
//{
//    public class ProductService : IProductService
//    {
//        IProductRepository _productRepository;
//<<<<<<< HEAD
//        IMapper _mapper;

//        public ProductService(IProductRepository productRepository, IMapper mapper)
//        {
//            _productRepository = productRepository;
//            _mapper = mapper;
//        }
//        //public async Task<List<ProductDTO>> GetProducts(int position, int skip, int? Product_Id, string? name, float? minPrice, float? maxPrice, int[]? CategoryIds, string? description)
//        //{

//        //    List<Product> listProduct = await _productRepository.GetProducts(position, skip, Product_Id, name, minPrice, maxPrice, CategoryIds, description);
//        //    List<ProductDTO> listProductDTO = _mapper.Map<List<Product>, List<ProductDTO>>(listProduct);
//        //    return listProductDTO;
//        //}


//            public async Task<List<ProductDTO>> GetProductsAsync(
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
//            )
//            {
//                var entities = await _productRepository.GetProductsAsync(
//                    categoryId, color, minPrice, maxPrice,
//                    justOnline, isClassic, isTrendy, isPearls, isStudio,
//                    sortMode
//                );

//                return _mapper.Map<List<ProductDTO>>(entities);
//            }
//        public async Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto)
//        {
//            var entity = _mapper.Map<Product>(dto);

//            var saved = await _productRepository.AddProductAsync(entity);

//            return _mapper.Map<ProductCreateDTO>(saved);
//        }

//        public async Task<ProductDetailsDto?> GetProductDetailsAsync(int id)
//        {
//            var product = await _productRepository.GetByIdWithSizesAsync(id);
//            if (product == null) return null;

//            var sizes = product.Sizes
//                .Where(s => s.Amount > 0) // ✅ לא מחזירים 0
//                .Select(s => new ProductSizeDto(s.ProductSize, s.Amount))
//                .ToList();

//            return new ProductDetailsDto(
//                product.ProductId,
//                product.ProductName,
//                product.LongDescription ?? "",
//                product.ProductPrice,
//                product.Image1,
//                product.Image2,
//                sizes
//            );
//        }

//    }


//=======
//        //AutoMapper _mapper;
//        IMapper _mapper;

//        JewelryStoreContext _jewelryStore;

//        //public ProductService(IProductRepository productRepository, IMapper mapper)
//        //{
//        //    _productRepository = productRepository;
//        //    _mapper = mapper;

//        //}

//        public ProductService(IProductRepository productRepository, IMapper mapper, JewelryStoreContext context)
//        {
//            _productRepository = productRepository;
//            _mapper = mapper;
//            _jewelryStore = context; // עכשיו _context (או _jewelryStore) יהיה מוכר
//        }

//        //public async Task<List<ProductCreateDTO>> GetProductsAsync(
//        //                                     int? categoryId,
//        //                                     string? color,
//        //                                     float? minPrice,
//        //                                     float? maxPrice,
//        //                                     bool? justOnline,
//        //                                     bool? isClassic,
//        //                                     bool? isTrendy,
//        //                                     bool? isPearls,
//        //                                     bool? isStudio,
//        //                                     string? sortMode
//        //                                 )
//        //{ 
//        //    // 1. שליפת המוצרים
//        //    var entities = await _productRepository.GetProductsAsync(
//        //        categoryId, color, minPrice, maxPrice,
//        //        justOnline, isClassic, isTrendy, isPearls, isStudio,
//        //        sortMode
//        //    );

//        //    // 2. מיפוי ראשוני ל-DTO (כאן הם מגיעים בלי המידות)
//        //    var initialDtos = _mapper.Map<List<ProductCreateDTO>>(entities);

//        //    // 3. שליפת כל המידות מה-DB
//        //    var allSizes = await _jewelryStore.Sizes.ToListAsync();



//        //    // 4. יצירת רשימה חדשה שבה לכל DTO יש את המידות שלו בעזרת 'with'
//        //    var updatedDtos = initialDtos.Select(dto =>
//        //    {
//        //        var productSizes = allSizes.Where(s => s.ProductId == dto.ProductId).ToList();
//        //        var sizeDtos = _mapper.Map<List<SizeDTO>>(productSizes);

//        //        // יצירת עותק חדש של ה-record עם רשימת המידות המעודכנת
//        //        return dto with { Sizes = sizeDtos };
//        //    }).ToList();
//        //    return updatedDtos;
//        //}


//        //public async Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto)
//        //{
//        //    var entity = _mapper.Map<Product>(dto);

//        //    // שולחים לרפוזיטורי את הישות ואת המידות - הוא יטפל בשניהם
//        //    var saved = await _productRepository.AddProductAsync(entity, dto.Sizes);

//        //    return _mapper.Map<ProductCreateDTO>(saved);
//        //}
//        //// הוסיפי ל-ProductService.cs
//        //public async Task UpdateProductAsync(int id, ProductCreateDTO dto)
//        //{
//        //    // מיפוי מה-DTO ל-Entity של Product
//        //    var entity = _mapper.Map<Product>(dto);

//        //    // חשוב לוודא שה-ID מהנתיב מעודכן בתוך האובייקט
//        //    entity.ProductId = id;

//        //    await _productRepository.UpdateProductAsync(id, entity, dto.Sizes);
//        //}

//        //public async Task DeleteProductAsync(int id)
//        //{
//        //    await _productRepository.DeleteProductAsync(id);
//        //}

//        public async Task<List<ProductCreateDTO>> GetProductsAsync(
//        int? categoryId, string? color, float? minPrice, float? maxPrice,
//        bool? justOnline, bool? isClassic, bool? isTrendy, bool? isPearls,
//        bool? isStudio, string? sortMode)
//        {
//            // 1. שליפת הישויות מהרפוזיטורי (הן כבר כוללות את המידות בגלל ה-Include)
//            var entities = await _productRepository.GetProductsAsync(
//                categoryId, color, minPrice, maxPrice,
//                justOnline, isClassic, isTrendy, isPearls, isStudio,
//                sortMode
//            );

//            // 2. מיפוי ל-DTO. בזכות הקשר ב-Context, המידות ימופו אוטומטית לתוך ה-Record
//            return _mapper.Map<List<ProductCreateDTO>>(entities);
//        }

//        public async Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto)
//        {
//            // מיפוי מ-DTO לישות (Entity) - המידות עוברות אוטומטית במיפוי
//            var entity = _mapper.Map<Product>(dto);

//            var saved = await _productRepository.AddProductAsync(entity);
//            return _mapper.Map<ProductCreateDTO>(saved);
//        }

//        public async Task UpdateProductAsync(int id, ProductCreateDTO dto)
//        {
//            var entity = _mapper.Map<Product>(dto);
//            entity.ProductId = id;

//            await _productRepository.UpdateProductAsync(id, entity);
//        }

//        public async Task DeleteProductAsync(int id)
//        {
//            await _productRepository.DeleteProductAsync(id);
//        }



//    }
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//}


using AutoMapper;
using DTOs;
using Entities;
using Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // 1. שליפת רשימת מוצרים (לדף הראשי/קטלוג)
        public async Task<List<ProductCreateDTO>> GetProductsAsync(
            int? categoryId, string? color, float? minPrice, float? maxPrice,
            bool? justOnline, bool? isClassic, bool? isTrendy, bool? isPearls,
            bool? isStudio, string? sortMode)
        {
            var entities = await _productRepository.GetProductsAsync(
                categoryId, color, minPrice, maxPrice,
                justOnline, isClassic, isTrendy, isPearls, isStudio,
                sortMode
            );

            return _mapper.Map<List<ProductCreateDTO>>(entities);
        }

        // 2. הוספת מוצר
        public async Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto)
        {
            var entity = _mapper.Map<Product>(dto);
            var saved = await _productRepository.AddProductAsync(entity);
            return _mapper.Map<ProductCreateDTO>(saved);
        }

        // 3. שליפת פרטי מוצר ספציפי (כולל מידות ומלאי)
        //public async Task<ProductDetailsDTO?> GetProductDetailsAsync(int id)
        //{
        //    var product = await _productRepository.GetByIdWithSizesAsync(id);
        //    if (product == null) return null;

        //    // סינון מידות שאינן במלאי
        //    var sizes = product.Sizes
        //        .Where(s => s.Amount > 0)
        //        .Select(s => new ProductSizeDto(s.ProductSize, s.Amount))
        //        .ToList();

        //    return new ProductDetailsDTO(
        //        product.ProductId,
        //        product.ProductName,
        //        product.LongDescription ?? "",
        //        product.ProductPrice,
        //        product.Image1,
        //        product.Image2,
        //        sizes
        //    );
        //}
        public async Task<ProductDetailsDTO?> GetProductDetailsAsync(int id)
        {
            var product = await _productRepository.GetByIdWithSizesAsync(id);
            if (product == null) return null;

            // המרת רשימת המידות מה-Entity ל-DTO
            var sizes = product.Sizes
                .Where(s => s.Amount > 0)
                .Select(s => new ProductSizeDto(
                    double.TryParse(s.ProductSize, out double sizeVal) ? sizeVal : 0, // המרה בטוחה מ-string ל-double
                    s.Amount
                ))
                .ToList();

            return new ProductDetailsDTO(
                product.ProductId,
                product.ProductName,
                product.LongDescription ?? "",
                (double)product.ProductPrice,
                product.Image1,
                product.Image2,
                sizes
            );
        }
        // 4. עדכון מוצר
        public async Task UpdateProductAsync(int id, ProductCreateDTO dto)
        {
            var entity = _mapper.Map<Product>(dto);
            entity.ProductId = id;
            await _productRepository.UpdateProductAsync(id, entity);
        }

        // 5. מחיקת מוצר
        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}
