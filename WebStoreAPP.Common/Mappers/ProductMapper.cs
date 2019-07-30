using DomainModels.DbModels;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.Common.Mappers
{
    public static partial class Mappers
    {
        public static Product ToModel(this ProductViewModel productViewModel) => new Product()
        {
            Id = productViewModel.Id,
            Naziv = productViewModel.Naziv,
            CategoryId = productViewModel.TipProizvoda,
            UserId = productViewModel.UserId.GetValueOrDefault(),
            DatumObjave = productViewModel.DatumObjave.GetValueOrDefault(),
            Adress = productViewModel.Adresa,
            
            Description = productViewModel.Opis,
            Price = productViewModel.Cijena,
            Auto = productViewModel.Auto == null ? null : productViewModel.Auto.ToModel()
        };

        public static ProductViewModel ToViewModel(this Product product) => new ProductViewModel()
        {
            Id = product.Id,
            Naziv = product.Naziv,
            TipProizvoda = product.CategoryId,
            UserId = product.UserId,
            DatumObjave = product.DatumObjave,
            Adresa = product.Adress,
            Cijena = product.Price,
            Opis = product.Description,
            
            Auto = product.Auto == null ? null : product.Auto.ToViewModel()
        };
    }
}