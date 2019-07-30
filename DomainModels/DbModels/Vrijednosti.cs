using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.DbModels
{
    public class Vrijednosti
    {
        public int Id { get; set; }
        public Proizvod ProizvodId { get; set; }
        public int SifarnikId { get; set; }
        public string Vrijednost { get; set; }
    }
}
