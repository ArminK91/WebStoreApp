using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using Microsoft.EntityFrameworkCore;
using WebStoreAPP.BLL.Interfaces;

namespace WebStoreAPP.BLL.CategoryService
{
    public class CategoryService : ICategory
    {

        readonly ApplicationDbContext _ctx;
       
       public CategoryService(IServiceProvider serviceProvider)
       {
           _ctx = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
       }

        public async Task DeleteCategory(int categoryId)
        {
            if (categoryId == null)
                throw new Exception("Nemoguce obrisati kategoriju!");

            var category = _ctx.Categories.Where(x => x.Id == categoryId).FirstOrDefault();

            _ctx.Categories.Remove(category);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var allCategories = await _ctx.Categories.ToListAsync();

            return allCategories;
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            if (categoryId == null)
                return null;
            var category = await _ctx.Categories.Where(c => c.Id == categoryId).FirstOrDefaultAsync();

            return category;
        }

        public async Task<Category> SaveCategory(Category model)
        {
            if (model == null)
                return null;

            _ctx.Categories.Add(model);

            await _ctx.SaveChangesAsync();

            return model;
        }

        public async Task<Category> UpdateCategory(Category model)
        {
            if (model == null)
                throw new Exception("Nemoguce uraditi edit kategorije!");

            var category = _ctx.Categories.FirstOrDefault(x => x.Id == model.Id);

            if(category == null)
                throw new Exception("Ne postoji kategoruija!");

            category.Name = model.Name;

            _ctx.Entry(category).State = EntityState.Modified;

            await _ctx.SaveChangesAsync();

            return category;
        }


    }
}