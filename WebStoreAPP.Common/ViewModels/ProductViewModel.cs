using System;
using System.Collections.Generic;


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

        //public bool Status { get; set; }

        public int TipProizvoda { get; set; }

        public int? UserId { get; set; }

        //public int? AutomobilId { get; set; }

        public DateTime? DatumObjave { get; set; }

        //public ICollection<ProductImagesViewModel> ProductImages { get; set; }

        public virtual AutomobilViewModel Auto { get; set; }
        //public ApplicationUserViewModel User { get; set; }
        //public Category Category { get; set; }
        public virtual ICollection<SlikaDetaljiDto> Slike { get; set; }
    }
}