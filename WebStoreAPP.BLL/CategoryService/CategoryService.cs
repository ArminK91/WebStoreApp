using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
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

        public Task<Category> DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategoryById(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> SaveCategory(Category model)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategory(Category model)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Category>> ICategory.GetAllCategories()
        {
            throw new NotImplementedException();
        }

        Task<Category> ICategory.GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}