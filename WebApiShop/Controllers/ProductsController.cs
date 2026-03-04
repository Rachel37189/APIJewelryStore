//<<<<<<< HEAD
//﻿using DTOs;
//using Entities;
//using Microsoft.AspNetCore.Mvc;
//using Repository;
//using Services;
//using System.Security.Cryptography;
//using System.Text.Json;
//using static WebApiShop.Controllers.UsersController;
//=======
//﻿using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;
//using static WebApiShop.Controllers.UsersController;
//using Entities;
//using Repository;
//using Services;
//using DTOs;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebApiShop.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductsController : ControllerBase
//    {
//<<<<<<< HEAD
//        public readonly IProductService _productService;
//=======

//        IProductService _productService ;
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//        public ProductsController(IProductService productService)
//        {
//            _productService = productService;
//        }

//<<<<<<< HEAD
//        // GET: api/<UsersController>
//        [HttpGet]
//        [HttpGet]
//        public async Task<ActionResult<List<ProductDTO>>> Get(
//                    int? categoryId,
//                    string? color,
//                    float? minPrice,
//                    float? maxPrice,
//                    bool? justOnline,
//                    bool? isClassic,
//                    bool? isTrendy,
//                    bool? isPearls,
//                    bool? isStudio,
//                    string? sortMode   // "low_to_high" / "high_to_low" / "date"
//)
//=======
//        [HttpGet]
//        public async Task<ActionResult<List<ProductCreateDTO>>> Get(
//                                              int? categoryId,
//                                              string? color,
//                                              float? minPrice,
//                                              float? maxPrice,
//                                              bool? justOnline,
//                                              bool? isClassic,
//                                              bool? isTrendy,
//                                              bool? isPearls,
//                                              bool? isStudio,
//                                              string? sortMode)// "low_to_high" / "high_to_low" / "date"
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//        {
//            var products = await _productService.GetProductsAsync(
//                categoryId, color, minPrice, maxPrice,
//                justOnline, isClassic, isTrendy, isPearls, isStudio,
//                sortMode
//            );

//            return Ok(products);
//        }
//<<<<<<< HEAD
//        [HttpGet("{id:int}")]
//        public async Task<ActionResult<ProductDetailsDto>> GetById(int id)
//        {
//            try
//            {
//                var product = await _productService.GetProductDetailsAsync(id);

//                if (product == null)
//                {
//                    return NotFound($"Product with id {id} not found");
//                }

//                return Ok(product);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, "Error retrieving product: " + ex.Message);
//            }
//        }
//=======

//        //[HttpPost]
//        //public async Task<ActionResult<ProductCreateDTO>> Post([FromBody] ProductCreateDTO dto)
//        //{
//        //    var created = await _productService.AddProductAsync(dto);

//        //    return CreatedAtAction(
//        //        nameof(Get),
//        //        new { id = created.ProductId },
//        //        created
//        //    );
//        //}
//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//        [HttpPost]
//        public async Task<ActionResult<ProductCreateDTO>> Post([FromBody] ProductCreateDTO dto)
//        {
//            var created = await _productService.AddProductAsync(dto);
//<<<<<<< HEAD

//            return CreatedAtAction(
//                nameof(Get),
//                new { id = created.ProductId },
//                created
//            );
//        }
//=======
//            // פשוט להחזיר Ok עם המוצר שנוצר
//            return Ok(created);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> Put(int id, [FromBody] ProductCreateDTO dto)
//        {
//            await _productService.UpdateProductAsync(id, dto);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> Delete(int id)
//        {
//            await _productService.DeleteProductAsync(id);
//            return NoContent();
//        }

//>>>>>>> 234722a0f9ae8bbfeb6eba645db360cb10d20bca
//    }
//}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs;
using Services;
using System;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //// GET: api/Products (עם כל הסינונים המורכבים שלך)
        //[HttpGet]
        //public async Task<ActionResult<List<ProductDTO>>> Get(
        //    [FromQuery] int? categoryId,
        //    [FromQuery] string? color,
        //    [FromQuery] float? minPrice,
        //    [FromQuery] float? maxPrice,
        //    [FromQuery] bool? justOnline,
        //    [FromQuery] bool? isClassic,
        //    [FromQuery] bool? isTrendy,
        //    [FromQuery] bool? isPearls,
        //    [FromQuery] bool? isStudio,
        //    [FromQuery] string? sortMode)
        //{
        //    var products = await _productService.GetProductsAsync(
        //        categoryId, color, minPrice, maxPrice,
        //        justOnline, isClassic, isTrendy, isPearls, isStudio,
        //        sortMode
        //    );

        //    return Ok(products);
        //}
        [HttpGet]
        public async Task<ActionResult<List<productDTO>>> Get(
                int? categoryId, string? color, float? minPrice, float? maxPrice,
                bool? justOnline, bool? isClassic, bool? isTrendy, bool? isPearls,
                bool? isStudio, string? sortMode)
        {
            var products = await _productService.GetProductsAsync(
                categoryId, color, minPrice, maxPrice,
                justOnline, isClassic, isTrendy, isPearls, isStudio,
                sortMode
            );
            return Ok(products);
        }
        // GET: api/Products/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDetailsDTO>> GetById(int id)
        {
            try
            {
                var product = await _productService.GetProductDetailsAsync(id);

                if (product == null)
                {
                    return NotFound($"Product with id {id} not found");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error retrieving product: " + ex.Message);
            }
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductCreateDTO>> Post([FromBody] ProductCreateDTO dto)
        {
            var created = await _productService.AddProductAsync(dto);

            // שימוש ב-CreatedAtAction נחשב ל-Best Practice ביצירת משאב חדש
            return CreatedAtAction(nameof(GetById), new { id = created.ProductId }, created);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductCreateDTO dto)
        {
            await _productService.UpdateProductAsync(id, dto);
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}