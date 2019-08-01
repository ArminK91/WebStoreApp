using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainModels.DbModels;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IAutomobil
    {
        Task<IEnumerable<Automobil>> DohvatiSveAutomobile();
        Task<IEnumerable<Proizvod>> DohvatiAutomobileZaUsera(string userName);
        Task<Automobil> SnimiAutomobil(Automobil automobil);
        Task<Automobil> AzurirajAutomobil(Automobil automobil);
        Task<bool> ObrisiAutomobil(int automobilId);
    }
}
