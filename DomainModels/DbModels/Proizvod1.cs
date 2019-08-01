using System;

namespace DomainModels.DbModels
{
    public class Proizvod1
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public int UserId { get; set; }
        public DateTime DatumObjave { get; set; }
    }
}
