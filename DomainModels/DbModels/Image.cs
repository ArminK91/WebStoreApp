using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.DbModels
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }
    }
}
