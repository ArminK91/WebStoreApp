using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.Common.Mappers;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        private IProduct _productService { get; set; }
        private IHelper _helperService { get; set; }
        private IImage  _imageService { get; set; }

        public ProductsController(IProduct productService, IHelper helperService, IImage imageService)
        {
            _productService = productService;
            _helperService = helperService;
            _imageService = imageService;
        }

        
        [HttpGet]
        [Route("getallproducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var currentUser = await _helperService.GetCurrentUserAsync();

                var products = await _productService.GetAllProducts();

                return Ok(products.Select(c => c.ToViewModel()));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpGet]
        [Route("getproductbyid/{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                var currentUser = _helperService.GetCurrentUserAsync();

                var product = await _productService.GetProductById(productId);

                return Ok(product.ToViewModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("saveproduct")]
        public async Task<IActionResult> SaveProduct([FromBody]ProductViewModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var currentUser = await _helperService.GetCurrentUserAsync();

                var dbProduct = model.ToModel();

                dbProduct = await _productService.SaveProduct(dbProduct, currentUser);

                return Ok(dbProduct.ToViewModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("updateproduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var currentUser = await _helperService.GetCurrentUserAsync();

                var dbModel = model.ToModel();

                dbModel = await _productService.UpdateProduct(dbModel, currentUser);

                return Ok(dbModel.ToViewModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteproduct/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var currentUser = await _helperService.GetCurrentUserAsync();

                await _productService.DeleteProduct(productId, currentUser);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}