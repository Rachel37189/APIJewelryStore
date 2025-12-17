using System.Reflection.Metadata;
using System.Text.Json;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class CategoryRepository :ICategoryRepository
    {
        WebApiShop216328971Context _shopContext;
        public CategoryRepository(WebApiShop216328971Context context)
        {
            _shopContext = context;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _shopContext.Categories.ToListAsync();
        }


        public void DeleteUser(int id)
        {
            //  _shopContext.Users.Delete(id);
        }


    }
}
