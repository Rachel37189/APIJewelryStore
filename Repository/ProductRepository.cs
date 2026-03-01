//using System.Reflection.Metadata;
//using System.Text.Json;
//using DTOs;
//using Entities;
//using Microsoft.EntityFrameworkCore;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//namespace Repository
//{
//    public class ProductRepository : IProductRepository
//    {
//        JewelryStoreContext _JewelryStore;
//        public ProductRepository(JewelryStoreContext context)
//        {
//            _JewelryStore = context;
//        }


//        // הוספת מוצר חדש + מידות
//        public async Task<Product> AddProductAsync(Product product, List<SizeDTO> sizes)
//        {
//            // 1. שמירת המוצר (זה עובד כי למוצר יש מפתח)
//            await _JewelryStore.Products.AddAsync(product);
//            await _JewelryStore.SaveChangesAsync(); // כאן נוצר ה-ProductId

//            // 2. הוספת המידות ב-SQL ישיר (עוקף את שגיאת ה-PrimaryKey)
//            if (sizes != null && sizes.Any())
//            {
//                foreach (var s in sizes)
//                {
//                    await _JewelryStore.Database.ExecuteSqlRawAsync(
//                        "INSERT INTO Sizes (ProductId, ProductSize, Amount) VALUES ({0}, {1}, {2})",
//                        product.ProductId, s.ProductSize, s.Amount);
//                }
//            }
//            return product;
//        }
//        //public async Task<(List<Product> Items, int TotalCount)> GetProducts(int? pId, string? name,int position, int skip, float? minPrice, float? maxPrice, string? desc, int?[] categoryIds)
//        //{
//        //    var query = _shopContext.Products.Where(product =>
//        //    (desc == null ? (true) : (product.Description.Contains(desc)))
//        //    && (name == null ? true : product.ProductName.Contains(name))
//        //    && ((minPrice == null) ? (true) : (product.Price >= minPrice))
//        //    && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
//        //    && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
//        //    .OrderBy(product => product.Price);

//        //    Console.WriteLine(query.ToQueryString());
//        //    List<Product> products = await query.Skip((position - 1) * skip)
//        //    .Take(skip).Include(product => product.Category).ToListAsync();
//        //    var total = await query.CountAsync();
//        //    return (products, total);
//        //}
//        public async Task<List<Product>> GetProductsAsync(
//                                            int? categoryId,
//                                            string? color,
//                                            float? minPrice,
//                                            float? maxPrice,
//                                            bool? justOnline,
//                                            bool? isClassic,
//                                            bool? isTrendy,
//                                            bool? isPearls,
//                                            bool? isStudio,
//                                            string? sortMode
//                                        )
//        {
//            IQueryable<Product> q = _JewelryStore.Products
//                .Include(p => p.Category);

//            // ---- Filters (רק אם הגיע ערך) ----
//            if (categoryId.HasValue)
//                q = q.Where(p => p.CategoryId == categoryId.Value);

//            if (!string.IsNullOrWhiteSpace(color))
//            {
//                var c = color.Trim().ToLower();
//                q = q.Where(p => p.Color.ToLower() == c);
//            }

//            if (minPrice.HasValue)
//                q = q.Where(p => p.ProductPrice >= minPrice.Value);

//            if (maxPrice.HasValue)
//                q = q.Where(p => p.ProductPrice <= maxPrice.Value);

//            if (justOnline.HasValue)
//                q = q.Where(p => p.JustOnline == justOnline.Value);

//            if (isClassic.HasValue)
//                q = q.Where(p => p.IsClassic == isClassic.Value);

//            if (isTrendy.HasValue)
//                q = q.Where(p => p.IsTrendy == isTrendy.Value);

//            if (isPearls.HasValue)
//                q = q.Where(p => p.IsPearls == isPearls.Value);

//            if (isStudio.HasValue)
//                q = q.Where(p => p.IsStudio == isStudio.Value);

//            // ---- Sort ----
//            var mode = (sortMode ?? "").Trim().ToLower();

//            q = mode switch
//            {
//                "high_to_low" => q.OrderByDescending(p => p.ProductPrice),
//                "date" => q.OrderByDescending(p => p.DateAdded), // <-- לשנות לשם השדה שלך
//                _ => q.OrderBy(p => p.ProductPrice),      // default: low_to_high
//            };
//            return await q.ToListAsync();


//        }




//        public async Task UpdateProductAsync(int id, Product product, List<SizeDTO> sizes)
//        {
//            // 1. עדכון פרטי המוצר
//            _JewelryStore.Products.Update(product);
//            await _JewelryStore.SaveChangesAsync();

//            // 2. מחיקת מידות קיימות ב-SQL ישיר
//            await _JewelryStore.Database.ExecuteSqlRawAsync("DELETE FROM Sizes WHERE ProductId = {0}", id);

//            // 3. הוספת המידות החדשות ב-SQL ישיר
//            if (sizes != null && sizes.Any())
//            {
//                foreach (var s in sizes)
//                {
//                    await _JewelryStore.Database.ExecuteSqlRawAsync(
//                        "INSERT INTO Sizes (ProductId, ProductSize, Amount) VALUES ({0}, {1}, {2})",
//                        id, s.ProductSize, s.Amount);
//                }
//            }
//        }

//        public async Task DeleteProductAsync(int id)
//        {
//            var product = await _JewelryStore.Products.FindAsync(id);
//            if (product != null)
//            {
//                _JewelryStore.Products.Remove(product);
//                await _JewelryStore.SaveChangesAsync();
//            }
//        }
//    }
//}


using DTOs;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly JewelryStoreContext _JewelryStore;

        public ProductRepository(JewelryStoreContext context)
        {
            _JewelryStore = context;
        }

        // 1. הוספת מוצר - פשוט ונקי
        public async Task<Product> AddProductAsync(Product product)
        {
            // בגלל שהגדרנו קשר ב-Context, EF יזהה את product.Sizes
            // וישמור אותם אוטומטית בטבלת Sizes עם ה-ProductId הנכון.
            await _JewelryStore.Products.AddAsync(product);
            await _JewelryStore.SaveChangesAsync();
            return product;
        }

        // 2. שליפת מוצרים עם המידות שלהם
        public async Task<List<Product>> GetProductsAsync(
            int? categoryId, string? color, float? minPrice, float? maxPrice,
            bool? justOnline, bool? isClassic, bool? isTrendy, bool? isPearls,
            bool? isStudio, string? sortMode)
        {
            // הוספנו Include ל-Sizes כדי שהם יגיעו יחד עם המוצר
            IQueryable<Product> q = _JewelryStore.Products
                .Include(p => p.Category)
                .Include(p => p.Sizes);

            // ---- פילטרים ----
            if (categoryId.HasValue) q = q.Where(p => p.CategoryId == categoryId.Value);

            if (!string.IsNullOrWhiteSpace(color))
            {
                var c = color.Trim().ToLower();
                q = q.Where(p => p.Color.ToLower() == c);
            }

            if (minPrice.HasValue) q = q.Where(p => p.ProductPrice >= minPrice.Value);
            if (maxPrice.HasValue) q = q.Where(p => p.ProductPrice <= maxPrice.Value);
            if (justOnline.HasValue) q = q.Where(p => p.JustOnline == justOnline.Value);
            if (isClassic.HasValue) q = q.Where(p => p.IsClassic == isClassic.Value);
            if (isTrendy.HasValue) q = q.Where(p => p.IsTrendy == isTrendy.Value);
            if (isPearls.HasValue) q = q.Where(p => p.IsPearls == isPearls.Value);
            if (isStudio.HasValue) q = q.Where(p => p.IsStudio == isStudio.Value);

            // ---- מיון ----
            var mode = (sortMode ?? "").Trim().ToLower();
            q = mode switch
            {
                "high_to_low" => q.OrderByDescending(p => p.ProductPrice),
                "date" => q.OrderByDescending(p => p.DateAdded),
                _ => q.OrderBy(p => p.ProductPrice),
            };

            return await q.ToListAsync();
        }

        // 3. עדכון מוצר
        public async Task UpdateProductAsync(int id, Product product)
        {
            // EF עוקב אחרי השינויים ב-Sizes באופן אוטומטי אם הן משויכות לישות
            _JewelryStore.Products.Update(product);
            await _JewelryStore.SaveChangesAsync();
        }

        // 4. מחיקת מוצר
        public async Task DeleteProductAsync(int id)
        {
            var product = await _JewelryStore.Products.FindAsync(id);
            if (product != null)
            {
                _JewelryStore.Products.Remove(product);
                await _JewelryStore.SaveChangesAsync();
            }
        }
    }
}