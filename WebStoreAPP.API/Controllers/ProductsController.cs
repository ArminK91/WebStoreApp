using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.Common.Enumi;
using WebStoreAPP.Common.Mappers;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : Controller
    {

        private IProduct _productService { get; set; }
        private IHelper _helperService { get; set; }
        private IImage  _imageService { get; set; }

        private IPathProvider _pathProvider;
 
        public ProductsController(IProduct productService, IHelper helperService, IImage imageService, IPathProvider pathProvider)
        {
            _productService = productService;
            _helperService = helperService;
            _imageService = imageService;
            _pathProvider = pathProvider;
        }

        [HttpGet]
        [Route("getproductsnew")]
        public async Task<IActionResult> GetNewProducts()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("getallproducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var currentUser = User.Identity.Name;

                var products = await _productService.GetAllProducts(currentUser);

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
                var currentUser = User.Identity.Name;

                var product = await _productService.GetProductById(productId, currentUser);

                return Ok(product.ToViewModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("saveproduct")]
        [Authorize]
        public async Task<IActionResult> SaveProduct([FromBody]ProductViewModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var currentUser = User.Identity.Name;

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

                var currentUser = User.Identity.Name;

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
                var currentUser = User.Identity.Name;

                await _productService.DeleteProduct(productId, currentUser);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("searchproducts/{term}/{kategorija}")]
        public async Task<IActionResult> TraziProizvode(string term, Kategorija kategorija)
        {
            try
            {
                if (term == null || term == "")
                    return BadRequest();

                var currentUser = User.Identity.Name;

                var proizvodi = await _productService.SearchProductsAsync(term, kategorija, currentUser);

                return Ok(proizvodi.Select(c => c.ToViewModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("uploadimage/{productId}")]
        public async Task<IActionResult> UploadImages(int productId)
        {

            try
            {
                Guid g = new Guid();
                g = Guid.NewGuid();

                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = g.ToString() + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    //snimi sada podatke u tabelu slika
                    var savedImage = await _imageService.SnimiPodatkeOSlici(dbPath, productId);


                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
    }
}