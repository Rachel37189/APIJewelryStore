using DTOs;
using Entities;

namespace Services
{
    public interface IProductService
    {
        //Task<List<productDto>> GetProducts(int? pId, string? name, int position, int skip, float? minPrice, float? maxPrice, string? desc, int?[] categoryIds);
        Task<List<productDto>> GetProductsAsync(
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
    }
}