using System;
using System.Collections.Generic;
using System.Text;
using DomainModels.DbModels;
using WebStoreAPP.Common.Enumi;

namespace WebStoreAPP.Common.ViewModels
{
    public class PorukaViewModel
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public DateTime? DatumObjave { get; set; }
        public int proizvodId { get; set; }

        public virtual ProductViewModel Proizvod { get; set; }

        public int ApplicationUserID { get; set; }

        public virtual UserViewModel User { get; set; }

        public StatusPoruke Status { get; set; }
    }
}
