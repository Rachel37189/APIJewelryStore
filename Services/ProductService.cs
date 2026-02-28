using AutoMapper;
using DTOs;
using Entities;
using Repository;
using System.Security.Cryptography;
namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        //public async Task<List<ProductDTO>> GetProducts(int position, int skip, int? Product_Id, string? name, float? minPrice, float? maxPrice, int[]? CategoryIds, string? description)
        //{

        //    List<Product> listProduct = await _productRepository.GetProducts(position, skip, Product_Id, name, minPrice, maxPrice, CategoryIds, description);
        //    List<ProductDTO> listProductDTO = _mapper.Map<List<Product>, List<ProductDTO>>(listProduct);
        //    return listProductDTO;
        //}
    

            public async Task<List<ProductDTO>> GetProductsAsync(
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

                return _mapper.Map<List<ProductDTO>>(entities);
            }
        public async Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto)
        {
            var entity = _mapper.Map<Product>(dto);

            var saved = await _productRepository.AddProductAsync(entity);

            return _mapper.Map<ProductCreateDTO>(saved);
        }

    }

    
}
