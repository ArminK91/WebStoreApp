using System.Collections.Generic;
using DomainModels.DbModels;
using WebStoreAPP.BLL.Interfaces;

namespace WebStoreAPP.BLL.ProductService
{
    public class ProductService : IProduct
    {
        public IEnumerable<Product> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}