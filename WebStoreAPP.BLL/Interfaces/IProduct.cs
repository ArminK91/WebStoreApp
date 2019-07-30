using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.DbModels;
using WebStoreAPP.Common.Enumi;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetAllProducts(string username);
        Task<Product> GetProductById(int productId, string username);
        Task<Product> SaveProduct(Product product, string username);
        Task<Product> UpdateProduct(Product product, string username);
        Task<List<Product>> GetAllProductForUser(int userId);
        Task<List<Product>> SearchProductsAsync(string term, Kategorija kategorija, string username);
        Task<List<Product>> SearchProductsByCategoryAsync(int categoryId, string username);
        Task<List<Product>> SerachProductsByPriceRangeAsync(decimal lowerBoundary, decimal higherBoundary, string username);
        Task DeleteProduct(int productId, string user);
    }
}