using DomainModels.DbModels;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.Common.Mappers
{
    public static partial class Mappers
    {
          public static Category ToModel(this CategoryViewModel categoryViewModel)
        {
            return new Category()
            {
                
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Name
            };
        }

        public static CategoryViewModel ToViewModel(this Category category)
        {
            return new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}