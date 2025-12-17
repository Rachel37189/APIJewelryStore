using DTOs;
using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<productDto>> GetProducts(int? pId, string? name, float? price, int? CategoryId, string? desc);
    }
}