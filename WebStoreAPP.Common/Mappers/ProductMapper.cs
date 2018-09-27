using DomainModels.DbModels;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.Common.Mappers
{
    public static class ProductMapper
    {
         public static Product ToProductModel(this ProductViewModel productViewModel)
        {
            return new Product()
            {
                // Barcode = productViewModel.Barcode,
                // CategoryId = productViewModel.CategoryId,
                // Description = productViewModel.Description,
                // Discounted = productViewModel.Discounted,
                Id = productViewModel.Id,
                //Name = productViewModel.Name,
                // UnitPrice = productViewModel.UnitPrice,
                // UnitsInStock = productViewModel.UnitsInStock,
                // UnitsOnOrder = productViewModel.UnitsOnOrder
            };
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel()
            {
                // Barcode = product.Barcode,
                // CategoryId = product.CategoryId,
                // Description = product.Description,
                // Discounted = product.Discounted,
                Id = product.Id,
                // Name = product.Name,
                // UnitPrice = product.UnitPrice,
                // UnitsInStock = product.UnitsInStock,
                // UnitsOnOrder = product.UnitsOnOrder
            };
        }
    }
}