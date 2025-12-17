using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static WebApiShop.Controllers.UsersController;
using Entities;
using Repository;
using Services;
using DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {

            List<CategoryDto> category = await _categoryService.GetCategories();
            if (category == null || category.Count()==0)
                return NoContent();                                              
            return Ok(category);
        }
   

   
    }
}
