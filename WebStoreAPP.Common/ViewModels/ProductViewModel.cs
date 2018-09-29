using System;

namespace WebStoreAPP.Common.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public decimal Price { get; set; }

        public DateTime? Age { get; set; }
        public string Color { get; set; }
        public string EngineType { get; set; }
        public decimal? Co2Emisions { get; set; }
        public string UserName { get; set; }

        public int? Kilometers { get; set; }
        public int? PreviousOwners { get; set; }
        public int? PackageOfEquipment { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
    }
}