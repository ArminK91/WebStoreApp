using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.DbModels;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int productId);
        Task<Product> SaveProduct(Product product, ApplicationUser user);
        Task<Product> UpdateProduct(Product product, ApplicationUser user);
        Task<List<Product>> GetAllProductForUser(int userId);
        Task<List<Product>> SearchProducts(string term);
        Task<List<Product>> SearchProductsByCategory(int categoryId);
        Task<List<Product>> SerachProductsByPriceRange(decimal lowerBoundary, decimal higherBoundary);
        Task DeleteProduct(int productId, ApplicationUser user);
    }
}