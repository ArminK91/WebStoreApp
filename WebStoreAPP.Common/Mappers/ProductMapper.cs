using System.Linq;
using DomainModels.DbModels;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.Common.Mappers
{
    public static partial class Mappers
    {
        public static Proizvod ToModel(this ProductViewModel productViewModel) => new Proizvod()
        {
            Id = productViewModel.Id,
            Naziv = productViewModel.Naziv,
            CategoryId = productViewModel.TipProizvoda,
            UsrId = productViewModel.UserId.GetValueOrDefault(),
            DatumObjave = productViewModel.DatumObjave.GetValueOrDefault(),
            Adress = productViewModel.Adresa,
            Description = productViewModel.Opis,
            Price = productViewModel.Cijena,
            Auto = productViewModel.Auto == null ? null : productViewModel.Auto.ToModel()
            //Slike = productViewModel.Slike.Count == 0 ? null : productViewModel.Slike.ToM
        };

        public static ProductViewModel ToViewModel(this Proizvod product) => new ProductViewModel()
        {
            Id = product.Id,
            Naziv = product.Naziv,
            TipProizvoda = product.CategoryId,
            UserId = product.UsrId,
            DatumObjave = product.DatumObjave,
            Adresa = product.Adress,
            Cijena = product.Price,
            Status = product.Status,
            StatusProizvoda = product.StatusProizvoda,
            Opis = product.Description,
            slikaUrl = product.Slike.Count == 0 ? null : product.Slike.FirstOrDefault().Url,
            Auto = product.Auto == null ? null : product.Auto.ToViewModel(),
            Slike = product.Slike == null ? null : product.Slike.Select(c => c.ToViewModel()),
            User = product.User == null ? null : product.User.ToViewModel()
        };

        public static SlikaDetaljiDto ToViewModel(this Slika slika) => new SlikaDetaljiDto()
        {
            Id = slika.Id,
            Glavna = slika.Glavna,
            Url = slika.Url,
            PublicId = slika.PublicId,
            DatumDodavanja = slika.DatumDodavanja,
            Opis = slika.Opis

        };
    }
}