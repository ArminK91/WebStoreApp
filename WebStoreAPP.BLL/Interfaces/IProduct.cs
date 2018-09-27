using System.Collections.Generic;
using DomainModels.DbModels;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IProduct
    {
         IEnumerable<Product> GetAllProducts();
         //Here need to implement other functionalities
    }
}