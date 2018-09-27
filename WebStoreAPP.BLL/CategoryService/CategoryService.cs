using System.Collections.Generic;
using DomainModels.DbModels;
using WebStoreAPP.BLL.Interfaces;

namespace WebStoreAPP.BLL.CategoryService
{
    public class CategoryService : ICategory
    {
        public IEnumerable<Category> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public Category GetCategoryById(int categoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}