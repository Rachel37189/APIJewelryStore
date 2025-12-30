using System.Reflection.Metadata;
using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        WebApiShop216328971Context _shopContext;
        public ProductRepository(WebApiShop216328971Context context)
        {
            _shopContext = context;
        }

        public async Task<List<Product>> GetProducts(int? pId,string? name,float? price,int? CategoryId,string? desc)
        {
            return await _shopContext.Products.ToListAsync();
        }







    }
}
