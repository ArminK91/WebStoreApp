using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.DbModels
{
    public class ProductImages
    {
        public int Id { get; set; }      
        public int ProductId { get; set; }
        public Proizvod Product { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
