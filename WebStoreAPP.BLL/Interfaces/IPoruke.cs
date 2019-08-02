using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainModels.DbModels;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IPoruke
    {
        Task<IEnumerable<Poruka>> DajPorukeZaProizvod(int proizvodId);
        Task<IEnumerable<Poruka>> SnimiPorukuZaProizvod(Poruka poruka);
        Task<IEnumerable<Poruka>> ObrisiPoruku(int porukaId);
    }
}
