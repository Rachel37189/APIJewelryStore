//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;
//using static WebApiShop.Controllers.UsersController;
//using Entities;
//using Repository;
//using Services;
//using DTOs;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebApiShop.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CategoriesController : ControllerBase
//    {

//<<<<<<< HEAD
//        public readonly ICategoryService _categoryService;
//=======
//        ICategoryService _categoryService;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//        public CategoriesController(ICategoryService categoryService)
//        {
//            _categoryService = categoryService;
//        }

//        // GET: api/<UsersController>
//        [HttpGet]
//<<<<<<< HEAD
//        public async Task<ActionResult<List<CategoryDTO>>> Get()
//        {
//            List<CategoryDTO> categories = await _categoryService.GetCategories();
//            if(categories == null || categories.Count() == 0)
//                return NoContent();
//            return Ok(categories);  
//        }


//=======
//        public async Task<ActionResult<List<CategoryDto>>> Get()
//        {

//            List<CategoryDto> category = await _categoryService.GetCategories();
//            if (category == null || category.Count()==0)
//                return NoContent();                                              
//            return Ok(category);
//        }



//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Services;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
            List<CategoryDTO> categories = await _categoryService.GetCategories();

            if (categories == null || !categories.Any())
                return NoContent(); // מחזיר 204 אם אין קטגוריות

            return Ok(categories); // מחזיר 200 עם הרשימה
        }
    }
}