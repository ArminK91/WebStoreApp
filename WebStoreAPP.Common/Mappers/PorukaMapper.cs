using System;
using System.Collections.Generic;
using System.Text;
using DomainModels.DbModels;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.Common.Mappers
{
    public static partial class Mappers
    {
        public static PorukaViewModel ToViewModel(this Poruka porukaVm) => new PorukaViewModel()
        {
            proizvodId = porukaVm.proizvodId,
            Id = porukaVm.Id,
            DatumObjave = porukaVm.DatumObjave,
            Status = porukaVm.Status,
            ApplicationUserID = porukaVm.ApplicationUserID,
            Tekst = porukaVm.Tekst,
            User = porukaVm.User == null ? null : porukaVm.User.ToViewModel()
        };

        public static Poruka ToModel(this PorukaViewModel porukaVm) => new Poruka()
        {
            proizvodId = porukaVm.proizvodId,
            Id = porukaVm.Id,
            DatumObjave = porukaVm.DatumObjave,
            Status = porukaVm.Status,
            ApplicationUserID = porukaVm.ApplicationUserID,
            Tekst = porukaVm.Tekst
            
        };

    }
}
