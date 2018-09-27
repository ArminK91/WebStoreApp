using DomainModels.DbModels;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.Common.Mappers
{
    public static class CategoryMapper
    {
          public static Category ToProductModel(this CategoryViewModel categoryViewModel)
        {
            return new Category()
            {
                // Barcode = productViewModel.Barcode,
                // CategoryId = productViewModel.CategoryId,
                // Description = productViewModel.Description,
                // Discounted = productViewModel.Discounted,
                Id = categoryViewModel.Id,
                //Name = productViewModel.Name,
                // UnitPrice = productViewModel.UnitPrice,
                // UnitsInStock = productViewModel.UnitsInStock,
                // UnitsOnOrder = productViewModel.UnitsOnOrder
            };
        }

        public static CategoryViewModel ToProductViewModel(this Category category)
        {
            return new CategoryViewModel()
            {
                // Barcode = product.Barcode,
                // CategoryId = product.CategoryId,
                // Description = product.Description,
                // Discounted = product.Discounted,
                Id = category.Id,
                // Name = product.Name,
                // UnitPrice = product.UnitPrice,
                // UnitsInStock = product.UnitsInStock,
                // UnitsOnOrder = product.UnitsOnOrder
            };
        }
    }
}