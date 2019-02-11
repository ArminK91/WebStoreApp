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
    public class CategoryController : Controller
    {

        private ICategory _categoryService { get; set; }

        public CategoryController(ICategory categoryService)
        {
            _categoryService = categoryService;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategories();

                return Ok(categories.Select(c => c.ToViewModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet]
        [Route("getcategorybyid/{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(categoryId);

                return Ok(category.ToViewModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        [Route("savecategory")]
        public async Task<IActionResult> SaveCategory([FromBody]CategoryViewModel model)
        {
            try
            {
                var category = await _categoryService.SaveCategory(model.ToModel());

                return Ok(category.ToViewModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void UpdateCategory(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("deletecategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                await _categoryService.DeleteCategory(categoryId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}