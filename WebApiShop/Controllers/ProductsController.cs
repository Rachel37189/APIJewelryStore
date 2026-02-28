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
    public class ProductsController : ControllerBase
    {

        IProductService _productService ;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<productDto>>> Get(
                                              int? categoryId,
                                              string? color,
                                              float? minPrice,
                                              float? maxPrice,
                                              bool? justOnline,
                                              bool? isClassic,
                                              bool? isTrendy,
                                              bool? isPearls,
                                              bool? isStudio,
                                              string? sortMode)// "low_to_high" / "high_to_low" / "date"
        {
            var products = await _productService.GetProductsAsync(
                categoryId, color, minPrice, maxPrice,
                justOnline, isClassic, isTrendy, isPearls, isStudio,
                sortMode
            );

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCreateDTO>> Post([FromBody] ProductCreateDTO dto)
        {
            var created = await _productService.AddProductAsync(dto);

            return CreatedAtAction(
                nameof(Get),
                new { id = created.ProductId },
                created
            );
        }
            

   



    }
}
