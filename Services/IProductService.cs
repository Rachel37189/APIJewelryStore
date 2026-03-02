using Entities;
using DTOs;
namespace Services
{
    public interface IProductService
    {
        
            Task<List<ProductDTO>> GetProductsAsync(
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
        Task<ProductCreateDTO> AddProductAsync(ProductCreateDTO dto);
        Task<ProductDetailsDto?> GetProductDetailsAsync(int id);
    }
}