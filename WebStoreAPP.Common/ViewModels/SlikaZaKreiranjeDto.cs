using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace WebStoreAPP.Common.ViewModels
{
    public class SlikaZaKreiranjeDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Opis { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public string PublicId { get; set; }

        public SlikaZaKreiranjeDto()
        {
            DatumDodavanja = DateTime.Now;
        }
    }

    public class SlikaDetaljiDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Opis { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public string PublicId { get; set; }
        public bool Glavna { get; set; }

    }
}
