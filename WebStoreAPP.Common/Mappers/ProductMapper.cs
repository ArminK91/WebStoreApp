using DomainModels.DbModels;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.Common.Mappers
{
    public static partial class Mappers
    {
         public static Product ToModel(this ProductViewModel productViewModel)
        {
            return new Product()
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Adress = productViewModel.Adress,
                Age = productViewModel.Age.GetValueOrDefault(),
                CategoryId = productViewModel.CategoryId,
                Co2Emisions = productViewModel.Co2Emisions.GetValueOrDefault(),
                Color = productViewModel.Color,
                Description = productViewModel.Description,
                EngineType = productViewModel.EngineType,
                Kilometers = productViewModel.Kilometers.GetValueOrDefault(),
                PackageOfEquipment = productViewModel.PackageOfEquipment.GetValueOrDefault(),
                PreviousOwners = productViewModel.PreviousOwners.GetValueOrDefault(),
                Price = productViewModel.Price,
                Status = productViewModel.Status,
                UserId = productViewModel.UserId
            };
        }

        public static ProductViewModel ToViewModel(this Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Adress = product.Adress,
                Age = product.Age,
                CategoryId = product.CategoryId,
                Co2Emisions = product.Co2Emisions,
                Color = product.Color,
                Description = product.Description,
                EngineType = product.EngineType,
                Kilometers = product.Kilometers,
                PackageOfEquipment = product.PackageOfEquipment,
                PreviousOwners = product.PreviousOwners,
                Price = product.Price,
                Status = product.Status,
                UserId = product.UserId

            };
        }
    }
}