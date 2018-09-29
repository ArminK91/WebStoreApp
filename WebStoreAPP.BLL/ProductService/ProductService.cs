using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using WebStoreAPP.BLL.Interfaces;

namespace WebStoreAPP.BLL.ProductService
{
    public class ProductService : IProduct
    {
        readonly ApplicationDbContext _ctx;

        public ProductService(IServiceProvider serviceProvider)
        {
            _ctx = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));            
        }

        public Task<Product> DeleteProduct(int productId, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProductForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> SaveProduct(Product product, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> SearchProducts(string term)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> SearchProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> SerachProductsByPriceRange(decimal lowerBoundary, decimal higherBoundary)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateProduct(Product product, ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProduct.GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}