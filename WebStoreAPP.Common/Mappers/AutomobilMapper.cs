using DomainModels.DbModels;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.Common.Mappers
{
    public static partial class Mappers
    {
        public static Automobil ToModel(this AutomobilViewModel automobilViewModel)
        {
            return new Automobil()
            {
                Id = automobilViewModel.Id,
                Marka = automobilViewModel.Marka,
                Godiste = automobilViewModel.Godiste,
                Boja = automobilViewModel.Boja,
                Opis = automobilViewModel.Opis,
                Kilometri = automobilViewModel.Kilometri,
                GrijaciSjedista = automobilViewModel.GrijaciSjedista,
                Klima = automobilViewModel.Klima,
                Zastita = automobilViewModel.Zastita,
                Xenoni = automobilViewModel.Xenoni,
                Siber = automobilViewModel.Siber,
                ServoVolan = automobilViewModel.ServoVolan,
                Registrovan = automobilViewModel.Registrovan,
                PodizaciStakala = automobilViewModel.PodizaciStakala,
                Motor = automobilViewModel.Motor,
                ProizvodId = automobilViewModel.ProizvodId.GetValueOrDefault()
            };
        }

        public static AutomobilViewModel ToViewModel(this Automobil automobil)
        {
            return new AutomobilViewModel()
            {
                Id = automobil.Id,
                Marka = automobil.Marka,
                Godiste = automobil.Godiste,
                Boja = automobil.Boja,
                Opis = automobil.Opis,
                Kilometri = automobil.Kilometri,
                GrijaciSjedista = automobil.GrijaciSjedista,
                Klima = automobil.Klima,
                Motor = automobil.Motor,
                PodizaciStakala = automobil.PodizaciStakala,
                Registrovan = automobil.Registrovan,
                ServoVolan = automobil.ServoVolan,
                Siber = automobil.Siber,
                Xenoni = automobil.Xenoni,
                Zastita = automobil.Zastita,
                ProizvodId = automobil.ProizvodId
            };
        }
    }
}