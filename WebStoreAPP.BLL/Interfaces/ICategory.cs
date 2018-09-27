using System.Collections.Generic;
using DomainModels.DbModels;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface ICategory
    {
         IEnumerable<Category> GetAllCategories();
         Category GetCategoryById(int categoryId);
    }
}