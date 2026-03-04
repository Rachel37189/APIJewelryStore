//<<<<<<< HEAD
//﻿using Entities;
//using Microsoft.EntityFrameworkCore;
//using Repository;
//using System.Reflection.Metadata;
//using System.Text.Json;
//=======
//﻿//using System.Reflection.Metadata;
////using System.Text.Json;
////using DTOs;
////using Entities;
////using Microsoft.EntityFrameworkCore;
////using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
////namespace Repository
////{
////    public class ProductRepository : IProductRepository
////    {
////        JewelryStoreContext _JewelryStore;
////        public ProductRepository(JewelryStoreContext context)
////        {
////            _JewelryStore = context;
////        }


////        // הוספת מוצר חדש + מידות
////        public async Task<Product> AddProductAsync(Product product, List<SizeDTO> sizes)
////        {
////            // 1. שמירת המוצר (זה עובד כי למוצר יש מפתח)
////            await _JewelryStore.Products.AddAsync(product);
////            await _JewelryStore.SaveChangesAsync(); // כאן נוצר ה-ProductId

////            // 2. הוספת המידות ב-SQL ישיר (עוקף את שגיאת ה-PrimaryKey)
////            if (sizes != null && sizes.Any())
////            {
////                foreach (var s in sizes)
////                {
////                    await _JewelryStore.Database.ExecuteSqlRawAsync(
////                        "INSERT INTO Sizes (ProductId, ProductSize, Amount) VALUES ({0}, {1}, {2})",
////                        product.ProductId, s.ProductSize, s.Amount);
////                }
////            }
////            return product;
////        }
////        //public async Task<(List<Product> Items, int TotalCount)> GetProducts(int? pId, string? name,int position, int skip, float? minPrice, float? maxPrice, string? desc, int?[] categoryIds)
////        //{
////        //    var query = _shopContext.Products.Where(product =>
////        //    (desc == null ? (true) : (product.Description.Contains(desc)))
////        //    && (name == null ? true : product.ProductName.Contains(name))
////        //    && ((minPrice == null) ? (true) : (product.Price >= minPrice))
////        //    && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
////        //    && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
////        //    .OrderBy(product => product.Price);

////        //    Console.WriteLine(query.ToQueryString());
////        //    List<Product> products = await query.Skip((position - 1) * skip)
////        //    .Take(skip).Include(product => product.Category).ToListAsync();
////        //    var total = await query.CountAsync();
////        //    return (products, total);
////        //}
////        public async Task<List<Product>> GetProductsAsync(
////                                            int? categoryId,
////                                            string? color,
////                                            float? minPrice,
////                                            float? maxPrice,
////                                            bool? justOnline,
////                                            bool? isClassic,
////                                            bool? isTrendy,
////                                            bool? isPearls,
////                                            bool? isStudio,
////                                            string? sortMode
////                                        )
////        {
////            IQueryable<Product> q = _JewelryStore.Products
////                .Include(p => p.Category);

////            // ---- Filters (רק אם הגיע ערך) ----
////            if (categoryId.HasValue)
////                q = q.Where(p => p.CategoryId == categoryId.Value);

////            if (!string.IsNullOrWhiteSpace(color))
////            {
////                var c = color.Trim().ToLower();
////                q = q.Where(p => p.Color.ToLower() == c);
////            }

////            if (minPrice.HasValue)
////                q = q.Where(p => p.ProductPrice >= minPrice.Value);

////            if (maxPrice.HasValue)
////                q = q.Where(p => p.ProductPrice <= maxPrice.Value);

////            if (justOnline.HasValue)
////                q = q.Where(p => p.JustOnline == justOnline.Value);

////            if (isClassic.HasValue)
////                q = q.Where(p => p.IsClassic == isClassic.Value);

////            if (isTrendy.HasValue)
////                q = q.Where(p => p.IsTrendy == isTrendy.Value);

////            if (isPearls.HasValue)
////                q = q.Where(p => p.IsPearls == isPearls.Value);

////            if (isStudio.HasValue)
////                q = q.Where(p => p.IsStudio == isStudio.Value);

////            // ---- Sort ----
////            var mode = (sortMode ?? "").Trim().ToLower();

////            q = mode switch
////            {
////                "high_to_low" => q.OrderByDescending(p => p.ProductPrice),
////                "date" => q.OrderByDescending(p => p.DateAdded), // <-- לשנות לשם השדה שלך
////                _ => q.OrderBy(p => p.ProductPrice),      // default: low_to_high
////            };
////            return await q.ToListAsync();


////        }




////        public async Task UpdateProductAsync(int id, Product product, List<SizeDTO> sizes)
////        {
////            // 1. עדכון פרטי המוצר
////            _JewelryStore.Products.Update(product);
////            await _JewelryStore.SaveChangesAsync();

////            // 2. מחיקת מידות קיימות ב-SQL ישיר
////            await _JewelryStore.Database.ExecuteSqlRawAsync("DELETE FROM Sizes WHERE ProductId = {0}", id);

////            // 3. הוספת המידות החדשות ב-SQL ישיר
////            if (sizes != null && sizes.Any())
////            {
////                foreach (var s in sizes)
////                {
////                    await _JewelryStore.Database.ExecuteSqlRawAsync(
////                        "INSERT INTO Sizes (ProductId, ProductSize, Amount) VALUES ({0}, {1}, {2})",
////                        id, s.ProductSize, s.Amount);
////                }
////            }
////        }

////        public async Task DeleteProductAsync(int id)
////        {
////            var product = await _JewelryStore.Products.FindAsync(id);
////            if (product != null)
////            {
////                _JewelryStore.Products.Remove(product);
////                await _JewelryStore.SaveChangesAsync();
////            }
////        }
////    }
////}


//using DTOs;
//using Entities;
//using Microsoft.EntityFrameworkCore;

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//namespace Repository
//{
//    public class ProductRepository : IProductRepository
//    {
//<<<<<<< HEAD

//        public readonly JewelryStoreContext _jewelryStoreContext;
//        public ProductRepository(JewelryStoreContext jewelryStoreContext)
//        {
//            _jewelryStoreContext = jewelryStoreContext;
//        }


//            public async Task<List<Product>> GetProductsAsync(
//                int? categoryId,
//                string? color,
//                float? minPrice,
//                float? maxPrice,
//                bool? justOnline,
//                bool? isClassic,
//                bool? isTrendy,
//                bool? isPearls,
//                bool? isStudio,
//                string? sortMode
//            )
//            {
//                IQueryable<Product> q = _jewelryStoreContext.Products
//                    .Include(p => p.Category);

//                // ---- Filters (רק אם הגיע ערך) ----
//                if (categoryId.HasValue)
//                    q = q.Where(p => p.CategoryId == categoryId.Value);

//            //if (!string.IsNullOrWhiteSpace(color))
//            //{
//            //    var c = color.Trim().ToLower();
//            //    q = q.Where(p => p.Color.ToLower() == c);
//            //}
//            if (!string.IsNullOrWhiteSpace(color))
//            {
//                var c = color.Trim();
//                q = q.Where(p => p.Color != null && p.Color.Trim() == c);
//            }
//            if (minPrice.HasValue)
//                    q = q.Where(p => p.ProductPrice >= minPrice.Value);

//                if (maxPrice.HasValue)
//                    q = q.Where(p => p.ProductPrice <= maxPrice.Value);

//                if (justOnline.HasValue)
//                    q = q.Where(p => p.JustOnline == justOnline.Value);

//                if (isClassic.HasValue)
//                    q = q.Where(p => p.IsClassic == isClassic.Value);

//                if (isTrendy.HasValue)
//                    q = q.Where(p => p.IsTrendy == isTrendy.Value);

//                if (isPearls.HasValue)
//                    q = q.Where(p => p.IsPearls == isPearls.Value);

//                if (isStudio.HasValue)
//                    q = q.Where(p => p.IsStudio == isStudio.Value);

//                // ---- Sort ----
//                var mode = (sortMode ?? "").Trim().ToLower();

//                q = mode switch
//                {
//                    "high_to_low" => q.OrderByDescending(p => p.ProductPrice),
//                    "date" => q.OrderByDescending(p => p.DateAdded), // <-- לשנות לשם השדה שלך
//                    _ => q.OrderBy(p => p.ProductPrice),      // default: low_to_high
//                };

//                return await q.ToListAsync();
//            }
//        public async Task<Product> AddProductAsync(Product product)
//        {
//            await _jewelryStoreContext.Products.AddAsync(product);
//            await _jewelryStoreContext.SaveChangesAsync();
//            return product;
//        }




//            public async Task<Product?> GetByIdWithSizesAsync(int id)
//            {
//                return await _jewelryStoreContext.Products
//                    .Include(p => p.Sizes)   // שנהי אם הניווט נקרא אחרת
//                    .FirstOrDefaultAsync(p => p.ProductId == id);
//            }

//    }




//}
//=======
//        private readonly JewelryStoreContext _JewelryStore;

//        public ProductRepository(JewelryStoreContext context)
//        {
//            _JewelryStore = context;
//        }

//        // 1. הוספת מוצר - פשוט ונקי
//        public async Task<Product> AddProductAsync(Product product)
//        {
//            // בגלל שהגדרנו קשר ב-Context, EF יזהה את product.Sizes
//            // וישמור אותם אוטומטית בטבלת Sizes עם ה-ProductId הנכון.
//            await _JewelryStore.Products.AddAsync(product);
//            await _JewelryStore.SaveChangesAsync();
//            return product;
//        }

//        // 2. שליפת מוצרים עם המידות שלהם
//        public async Task<List<Product>> GetProductsAsync(
//            int? categoryId, string? color, float? minPrice, float? maxPrice,
//            bool? justOnline, bool? isClassic, bool? isTrendy, bool? isPearls,
//            bool? isStudio, string? sortMode)
//        {
//            // הוספנו Include ל-Sizes כדי שהם יגיעו יחד עם המוצר
//            IQueryable<Product> q = _JewelryStore.Products
//                .Include(p => p.Category)
//                .Include(p => p.Sizes);

//            // ---- פילטרים ----
//            if (categoryId.HasValue) q = q.Where(p => p.CategoryId == categoryId.Value);

//            if (!string.IsNullOrWhiteSpace(color))
//            {
//                var c = color.Trim().ToLower();
//                q = q.Where(p => p.Color.ToLower() == c);
//            }

//            if (minPrice.HasValue) q = q.Where(p => p.ProductPrice >= minPrice.Value);
//            if (maxPrice.HasValue) q = q.Where(p => p.ProductPrice <= maxPrice.Value);
//            if (justOnline.HasValue) q = q.Where(p => p.JustOnline == justOnline.Value);
//            if (isClassic.HasValue) q = q.Where(p => p.IsClassic == isClassic.Value);
//            if (isTrendy.HasValue) q = q.Where(p => p.IsTrendy == isTrendy.Value);
//            if (isPearls.HasValue) q = q.Where(p => p.IsPearls == isPearls.Value);
//            if (isStudio.HasValue) q = q.Where(p => p.IsStudio == isStudio.Value);

//            // ---- מיון ----
//            var mode = (sortMode ?? "").Trim().ToLower();
//            q = mode switch
//            {
//                "high_to_low" => q.OrderByDescending(p => p.ProductPrice),
//                "date" => q.OrderByDescending(p => p.DateAdded),
//                _ => q.OrderBy(p => p.ProductPrice),
//            };

//            return await q.ToListAsync();
//        }

//        // 3. עדכון מוצר
//        public async Task UpdateProductAsync(int id, Product product)
//        {
//            // EF עוקב אחרי השינויים ב-Sizes באופן אוטומטי אם הן משויכות לישות
//            _JewelryStore.Products.Update(product);
//            await _JewelryStore.SaveChangesAsync();
//        }

//        // 4. מחיקת מוצר
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
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca



using DTOs;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly JewelryStoreContext _jewelryStoreContext;

        public ProductRepository(JewelryStoreContext jewelryStoreContext)
        {
            _jewelryStoreContext = jewelryStoreContext;
        }

        // 1. שליפת מוצרים עם פילטרים, קטגוריות ומידות
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
            string? sortMode)
        {
            IQueryable<Product> q = _jewelryStoreContext.Products
                .Include(p => p.Category)
                .Include(p => p.Sizes);

            // ---- פילטרים ----
            if (categoryId.HasValue)
                q = q.Where(p => p.CategoryId == categoryId.Value);

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
                _ => q.OrderBy(p => p.ProductPrice), // ברירת מחדל: מהזול ליקר
            };

            return await q.ToListAsync();
        }

        // 2. הוספת מוצר (EF יטפל אוטומטית במידות שבתוך האובייקט)
        public async Task<Product> AddProductAsync(Product product)
        {
            await _jewelryStoreContext.Products.AddAsync(product);
            await _jewelryStoreContext.SaveChangesAsync();
            return product;
        }

        // 3. שליפת מוצר ספציפי עם המידות שלו
        public async Task<Product?> GetByIdWithSizesAsync(int id)
        {
            return await _jewelryStoreContext.Products
                .Include(p => p.Sizes)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        // 4. עדכון מוצר
        public async Task UpdateProductAsync(int id, Product product)
        {
            _jewelryStoreContext.Products.Update(product);
            await _jewelryStoreContext.SaveChangesAsync();
        }

        // 5. מחיקת מוצר
        public async Task DeleteProductAsync(int id)
        {
            var product = await _jewelryStoreContext.Products.FindAsync(id);
            if (product != null)
            {
                _jewelryStoreContext.Products.Remove(product);
                await _jewelryStoreContext.SaveChangesAsync();
            }
        }
    }
}
