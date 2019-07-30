using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels.DbModels
{
    public class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImages>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string Naziv { get; set; }

        public string Adress { get; set; }

        public decimal Price { get; set; }
      
        public bool Status { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }

        //public int? AutomobilId { get; set; }

        public DateTime DatumObjave { get; set; }
        
        public ICollection<ProductImages> ProductImages { get; set; }

        //[ForeignKey("AutomobilId")]
        public Automobil Auto { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }
        //[ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public virtual ICollection<Slika> Slike { get; set; }
    }
}