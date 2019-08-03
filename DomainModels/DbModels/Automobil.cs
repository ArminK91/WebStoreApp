using System;
using System.Collections.Generic;
using System.Text;
using WebStoreAPP.Common.Enumi;

namespace DomainModels.DbModels
{
    public class Automobil 
    {
        public int Id { get; set; }
        public string Boja { get; set; }
        public string Marka { get; set; }
        public string Opis { get; set; }
        public decimal Kilometri { get; set; }
        public string Godiste { get; set; }
        public string Motor { get; set; }
        public bool PodizaciStakala { get; set; }
        public bool ServoVolan { get; set; }
        public bool Klima { get; set; }
        public bool Zastita { get; set; }
        public bool Xenoni { get; set; }
        public bool GrijaciSjedista { get; set; }
        public bool Siber { get; set; }
        public bool Registrovan { get; set; }
        public int ProizvId { get; set; }
        public decimal Cijena { get; set; }
        public StatusSloga Status { get; set; }
    }
}
