using Entities;

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
        //Task<Product> AddProduct(Product product);
        Task<Product> AddProductAsync(Product product);
        Task<Product?> GetByIdWithSizesAsync(int id);
    }

}