using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Reflection.Metadata;
using System.Text.Json;
namespace Repository
{
    public class ProductRepository : IProductRepository
    {

        public readonly JewelryStoreContext _jewelryStoreContext;
        public ProductRepository(JewelryStoreContext jewelryStoreContext)
        {
            _jewelryStoreContext = jewelryStoreContext;
        }


            public async Task<List<Product>> GetProductsAsync(
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
                IQueryable<Product> q = _jewelryStoreContext.Products
                    .Include(p => p.Category);

                // ---- Filters (רק אם הגיע ערך) ----
                if (categoryId.HasValue)
                    q = q.Where(p => p.CategoryId == categoryId.Value);

                if (!string.IsNullOrWhiteSpace(color))
                {
                    var c = color.Trim().ToLower();
                    q = q.Where(p => p.Color.ToLower() == c);
                }

                if (minPrice.HasValue)
                    q = q.Where(p => p.ProductPrice >= minPrice.Value);

                if (maxPrice.HasValue)
                    q = q.Where(p => p.ProductPrice <= maxPrice.Value);

                if (justOnline.HasValue)
                    q = q.Where(p => p.JustOnline == justOnline.Value);

                if (isClassic.HasValue)
                    q = q.Where(p => p.IsClassic == isClassic.Value);

                if (isTrendy.HasValue)
                    q = q.Where(p => p.IsTrendy == isTrendy.Value);

                if (isPearls.HasValue)
                    q = q.Where(p => p.IsPearls == isPearls.Value);

                if (isStudio.HasValue)
                    q = q.Where(p => p.IsStudio == isStudio.Value);

                // ---- Sort ----
                var mode = (sortMode ?? "").Trim().ToLower();

                q = mode switch
                {
                    "high_to_low" => q.OrderByDescending(p => p.ProductPrice),
                    "date" => q.OrderByDescending(p => p.DateAdded), // <-- לשנות לשם השדה שלך
                    _ => q.OrderBy(p => p.ProductPrice),      // default: low_to_high
                };

                return await q.ToListAsync();
            }
        public async Task<Product> AddProductAsync(Product product)
        {
            await _jewelryStoreContext.Products.AddAsync(product);
            await _jewelryStoreContext.SaveChangesAsync();
            return product;
        }
    }



    
}
