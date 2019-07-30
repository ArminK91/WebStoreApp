
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreAPP.Common.Enumi;

namespace DomainModels.DbModels
{
    public class Sifarnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public TipSif TipSif { get; set; }
        public string Naziv { get; set; }
        public int? RoditeljId { get; set; }
        public int Vrijednost { get; set; }
    }
}
