using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Reflection.Metadata;
using System.Text.Json;
namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        JewelryStoreContext _jewelryStoreContext;
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
