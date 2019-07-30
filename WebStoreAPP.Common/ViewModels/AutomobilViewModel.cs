using System;
using System.Collections.Generic;
using System.Text;

namespace WebStoreAPP.Common.ViewModels
{
    public class AutomobilViewModel
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public string Marka { get; set; }
        public decimal Kilometri { get; set; }
        public DateTime Godiste { get; set; }
        public string Boja { get; set; }
        public string Motor { get; set; }
        public bool PodizaciStakala { get; set; }
        public bool ServoVolan { get; set; }
        public bool Klima { get; set; }
        public bool Zastita { get; set; }
        public bool Xenoni { get; set; }
        public bool GrijaciSjedista { get; set; }
        public bool Siber { get; set; }
        public bool Registrovan { get; set; }
        public int Status { get; set; }
        public int? ProizvodId { get; set; }  
    }
}
