// Code generated by DevUp technologies, 02/08/2024 14:36:01
using CommonInterfaces;
using CommonServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using InventoryManagementWApi.Auth;

namespace InventoryManagementWApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
		
        //HttpGet: ProductController/GetAll
        [HttpGet("GetAll")]
		[AuthorizeRequest(DemandedRoles.NoSecurity)]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
			var products = await _productService.GetAll();
            return products;
        }
		
		//HttpPost: ProductController/GetByFilter
        [HttpGet("GetTotal")]
		[AuthorizeRequest(DemandedRoles.NoSecurity)]
        public async Task<ActionResult<int>> GetTotal()
        {
            var totalCount = await _productService.GetTotal();
            return totalCount;
        }
		
		//HttpGet: ProductController/GetById
        [HttpGet("GetById")]
		[AuthorizeRequest(DemandedRoles.NoSecurity)]
        public async Task<ActionResult<ProductDTO>> GetProduct(long id)
        {
			Trace.WriteLine($"GetById invoked:id={id}");
			var product = await _productService.GetById(id);
			if (product == null)
			{
				return NotFound();
			}
			return product;
        }

		//HttpPost: ProductController/GetByFilter
        [HttpPost("GetByFilter")]
		[AuthorizeRequest(DemandedRoles.NoSecurity)]
        public async Task<ActionResult<List<ProductDTO>>> GetByFilter([FromBody] ProductFilterDTO filter)
        {
			var products = await _productService.GetByFilter(filter);
			return products;
        }
		
		//HttpPost: ProductController/GetByFilterTotal/
        [HttpPost("GetByFilterTotal")]
		[AuthorizeRequest(DemandedRoles.NoSecurity)]
        public async Task<ActionResult<int>> GetByFilterTotal([FromBody] ProductFilterDTO filter)
        {
            var totalCount = await _productService.GetByFilterTotal(filter);
            return totalCount;
        }

        // Post: ProductController/Create
        [HttpPost("Create")]
		[AuthorizeRequest(DemandedRoles.NoSecurity)]
        public async Task<ActionResult<bool>> CreateProduct([FromBody] ProductDTO dataItem)
        {
			var result = await _productService.Create(dataItem);
			return result;
        }
		
		// Post: ProductController/CreateGetId
        [HttpPost("CreateGetId")]
		[AuthorizeRequest(DemandedRoles.NoSecurity)]
        public async Task<ActionResult<long>> CreateGetIdProduct([FromBody] ProductDTO dataItem)
        {
			var result = await _productService.CreateGetId(dataItem);
			return result;
        }

        // Put: ProductController/Edit/5
        [HttpPut("Update")]
		[AuthorizeRequest(DemandedRoles.NoSecurity)]
        public async Task<ActionResult<bool>> UpdateProduct(long id, [FromBody] ProductDTO dataItem)
        {
			var product = _productService.GetById(id);
			if (product == null)
				return NotFound();
			else
			{
				var result = await _productService.Update(dataItem);
				return result;
			}
        }

        //HttpDelete: ProductController/Delete/5
        [HttpDelete("Delete")]
		[AuthorizeRequest(DemandedRoles.NoSecurity)]
        public async Task<ActionResult<bool>> DeleteProduct(long id)
        {
			Trace.WriteLine($"Delete invoked:id:{id}");

			var product = _productService.GetById(id);
			if (product == null)
				return NotFound();
			else
			{
				var result = await _productService.DeleteById(id);
				return result;
			}
        }

    }
}

