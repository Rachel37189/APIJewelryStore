using Entities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Testing.Values;
using Repository;
using System.Collections.Generic;
using DTOs;
using AutoMapper;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        //AutoMapper _mapper;
        IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        public async Task<List<productDto>> GetProductsAsync(
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
                                         )
        {
            var entities = await _productRepository.GetProductsAsync(
                categoryId, color, minPrice, maxPrice,
                justOnline, isClassic, isTrendy, isPearls, isStudio,
                sortMode
            );

            return _mapper.Map<List<productDto>>(entities);
        }

        public async Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto)
        {
            var entity = _mapper.Map<Product>(dto);

            var saved = await _productRepository.AddProductAsync(entity);

            return _mapper.Map<ProductCreateDTO>(saved);
        }

    }
}
