using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreAPP.Common.Enumi;

namespace DomainModels.DbModels
{
    public class Proizvod
    {
        public Proizvod()
        {
            ProductImages = new HashSet<ProductImages>();
            Slike = new HashSet<Slika>();
            Poruke = new HashSet<Poruka>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string Naziv { get; set; }

        public string Adress { get; set; }

        public decimal Price { get; set; }
      
        public StatusSloga Status { get; set; }

        public int CategoryId { get; set; }

        public StatusProizvoda StatusProizvoda { get; set; }

        public int UsrId { get; set; }

        //public int? AutomobilId { get; set; }

        public DateTime DatumObjave { get; set; }
        
        public ICollection<ProductImages> ProductImages { get; set; }

        //[ForeignKey("AutomobilId")]
        public Automobil Auto { get; set; }
        //[ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        //[ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Slika> Slike { get; set; }

        public virtual ICollection<Poruka> Poruke { get; set; }
    }
}