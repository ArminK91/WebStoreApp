
using System;
using System.Collections.Generic;

namespace DomainModels.DbModels
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Proizvod> Proizvodi { get; set; }
    }
}