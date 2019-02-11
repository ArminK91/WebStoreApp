using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.DbModels;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface ICategory
    {
         Task<IEnumerable<Category>> GetAllCategories();
         Task<Category> GetCategoryById(int categoryId);
        Task<Category> SaveCategory(Category model);
        Task<Category> UpdateCategory(Category model);
        Task DeleteCategory(int categoryId);
    }
}