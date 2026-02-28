using System.Reflection.Metadata;
using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class CategoryRepository :ICategoryRepository
    {
        JewelryStoreContext _JewelryStore;
        public CategoryRepository(JewelryStoreContext context)
        {
            _JewelryStore = context;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _JewelryStore.Categories.ToListAsync();
        }


        public void DeleteUser(int id)
        {
            //  _shopContext.Users.Delete(id);
        }


    }
}
