using System;
using System.Collections.Generic;
using System.Text;
using WebStoreAPP.Common.Enumi;

namespace DomainModels.DbModels
{
    public class Poruka
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public DateTime? DatumObjave { get; set; }
        public int proizvodId { get; set; }

        public virtual Proizvod Proizvod { get; set; }

        public int ApplicationUserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        public StatusPoruke Status { get; set; }
    }
}
