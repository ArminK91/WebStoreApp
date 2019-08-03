using System;
using System.Collections.Generic;
using WebStoreAPP.Common.Enumi;


namespace WebStoreAPP.Common.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
                //Auto = new AutomobilViewModel();
        }

        public int Id { get; set; }

        public string Opis { get; set; }

        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public decimal Cijena { get; set; }

        public int TipProizvoda { get; set; }

        public int? UserId { get; set; }

        public string slikaUrl { get; set; }

        //public int? AutomobilId { get; set; }

        public DateTime? DatumObjave { get; set; }
        public StatusProizvoda StatusProizvoda { get; set; }
        public StatusSloga Status { get; set; }
        

        public virtual AutomobilViewModel Auto { get; set; }

        public virtual UserViewModel User { get; set; }
        //public ApplicationUserViewModel User { get; set; }
        //public Category Category { get; set; }
        public virtual IEnumerable<SlikaDetaljiDto> Slike { get; set; }

        public string StatusSlogaOpis
        {
            get { return Status == StatusSloga.AKTIVAN ? "Aktivan" : "Neaktivan"; }
        }

        public string StatusProizvodaOpis
        {
            get { return StatusProizvoda == StatusProizvoda.AKTIVAN ? "Aktivan" : "Okončan"; }
        }
    }
}