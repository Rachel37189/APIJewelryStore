using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text.Json;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JewelryStoreContext _jewelryStoreContext;

        public CategoryRepository(JewelryStoreContext jewelryStoreContext)
        {
            _jewelryStoreContext = jewelryStoreContext;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _jewelryStoreContext.Categories.ToListAsync();
        }
    }
}