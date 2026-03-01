using Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Testing.Values;
using Repository;
using System.Collections.Generic;
using DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        //AutoMapper _mapper;
        IMapper _mapper;

        JewelryStoreContext _jewelryStore;

        //public ProductService(IProductRepository productRepository, IMapper mapper)
        //{
        //    _productRepository = productRepository;
        //    _mapper = mapper;

        //}

        public ProductService(IProductRepository productRepository, IMapper mapper, JewelryStoreContext context)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _jewelryStore = context; // עכשיו _context (או _jewelryStore) יהיה מוכר
        }

        //public async Task<List<ProductCreateDTO>> GetProductsAsync(
        //                                     int? categoryId,
        //                                     string? color,
        //                                     float? minPrice,
        //                                     float? maxPrice,
        //                                     bool? justOnline,
        //                                     bool? isClassic,
        //                                     bool? isTrendy,
        //                                     bool? isPearls,
        //                                     bool? isStudio,
        //                                     string? sortMode
        //                                 )
        //{ 
        //    // 1. שליפת המוצרים
        //    var entities = await _productRepository.GetProductsAsync(
        //        categoryId, color, minPrice, maxPrice,
        //        justOnline, isClassic, isTrendy, isPearls, isStudio,
        //        sortMode
        //    );

        //    // 2. מיפוי ראשוני ל-DTO (כאן הם מגיעים בלי המידות)
        //    var initialDtos = _mapper.Map<List<ProductCreateDTO>>(entities);

        //    // 3. שליפת כל המידות מה-DB
        //    var allSizes = await _jewelryStore.Sizes.ToListAsync();



        //    // 4. יצירת רשימה חדשה שבה לכל DTO יש את המידות שלו בעזרת 'with'
        //    var updatedDtos = initialDtos.Select(dto =>
        //    {
        //        var productSizes = allSizes.Where(s => s.ProductId == dto.ProductId).ToList();
        //        var sizeDtos = _mapper.Map<List<SizeDTO>>(productSizes);

        //        // יצירת עותק חדש של ה-record עם רשימת המידות המעודכנת
        //        return dto with { Sizes = sizeDtos };
        //    }).ToList();
        //    return updatedDtos;
        //}


        //public async Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto)
        //{
        //    var entity = _mapper.Map<Product>(dto);

        //    // שולחים לרפוזיטורי את הישות ואת המידות - הוא יטפל בשניהם
        //    var saved = await _productRepository.AddProductAsync(entity, dto.Sizes);

        //    return _mapper.Map<ProductCreateDTO>(saved);
        //}
        //// הוסיפי ל-ProductService.cs
        //public async Task UpdateProductAsync(int id, ProductCreateDTO dto)
        //{
        //    // מיפוי מה-DTO ל-Entity של Product
        //    var entity = _mapper.Map<Product>(dto);

        //    // חשוב לוודא שה-ID מהנתיב מעודכן בתוך האובייקט
        //    entity.ProductId = id;

        //    await _productRepository.UpdateProductAsync(id, entity, dto.Sizes);
        //}

        //public async Task DeleteProductAsync(int id)
        //{
        //    await _productRepository.DeleteProductAsync(id);
        //}

        public async Task<List<ProductCreateDTO>> GetProductsAsync(
        int? categoryId, string? color, float? minPrice, float? maxPrice,
        bool? justOnline, bool? isClassic, bool? isTrendy, bool? isPearls,
        bool? isStudio, string? sortMode)
        {
            // 1. שליפת הישויות מהרפוזיטורי (הן כבר כוללות את המידות בגלל ה-Include)
            var entities = await _productRepository.GetProductsAsync(
                categoryId, color, minPrice, maxPrice,
                justOnline, isClassic, isTrendy, isPearls, isStudio,
                sortMode
            );

            // 2. מיפוי ל-DTO. בזכות הקשר ב-Context, המידות ימופו אוטומטית לתוך ה-Record
            return _mapper.Map<List<ProductCreateDTO>>(entities);
        }

        public async Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto)
        {
            // מיפוי מ-DTO לישות (Entity) - המידות עוברות אוטומטית במיפוי
            var entity = _mapper.Map<Product>(dto);

            var saved = await _productRepository.AddProductAsync(entity);
            return _mapper.Map<ProductCreateDTO>(saved);
        }

        public async Task UpdateProductAsync(int id, ProductCreateDTO dto)
        {
            var entity = _mapper.Map<Product>(dto);
            entity.ProductId = id;

            await _productRepository.UpdateProductAsync(id, entity);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }



    }
}
