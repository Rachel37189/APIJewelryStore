using DTOs;
using Entities;

namespace Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategories();
    }
}