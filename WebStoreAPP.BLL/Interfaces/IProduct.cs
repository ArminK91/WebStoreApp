using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.DbModels;
using WebStoreAPP.Common.Enumi;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IProduct
    {
        Task<IEnumerable<Proizvod>> GetAllProducts(string username);
        Task<Proizvod> GetProductById(int productId, string username);
        Task<Proizvod> SaveProduct(Proizvod product, string username);
        Task<Proizvod> UpdateProduct(Proizvod product, string username);
        Task<List<Proizvod>> GetAllProductForUser(string userName);
        Task<List<Proizvod>> SearchProductsAsync(string term, Kategorija kategorija, string username);
        Task<List<Proizvod>> SearchProductsByCategoryAsync(int categoryId, string username);
        Task<List<Proizvod>> SerachProductsByPriceRangeAsync(decimal lowerBoundary, decimal higherBoundary, string username);
        Task DeleteProduct(int productId, string user);
        Task<IEnumerable<Proizvod>> OkoncajProizvod(int productId, string user);

    }
}