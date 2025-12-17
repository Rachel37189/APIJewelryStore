using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts(int? pId, string? name, float? price, int? CategoryId, string? desc);
    }
}