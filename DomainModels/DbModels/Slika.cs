using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.DbModels
{
    public class Slika
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Opis { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public bool Glavna { get; set; }
        public string PublicId { get; set; }
        public Proizvod Proizvod { get; set; }
        public int ProizvodId { get; set; }

    }
}
