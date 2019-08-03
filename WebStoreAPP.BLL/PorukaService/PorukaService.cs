using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.Common.Enumi;

namespace WebStoreAPP.BLL.PorukaService
{
    public class PorukaService : IPoruke
    {

        readonly ApplicationDbContext _ctx;

        public PorukaService(IServiceProvider serviceProvider)
        {
            _ctx = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
        }


        public async Task<IEnumerable<Poruka>> DajPorukeZaProizvod(int proizvodId)
        {
            var porukeProizvoda = await _ctx.Poruke.Include(i => i.User).Where(x => x.proizvodId == proizvodId && x.Status == StatusPoruke.AKTIVNA).ToListAsync();
            return porukeProizvoda;
        }

        public async Task<IEnumerable<Poruka>> SnimiPorukuZaProizvod(Poruka poruka, string userName)
        {
            var korisnik = await _ctx.Users.FirstOrDefaultAsync(x => x.Username == userName);


            poruka.Status = StatusPoruke.AKTIVNA;
            poruka.ApplicationUserID = korisnik.Id;
            poruka.DatumObjave = DateTime.Now;

            _ctx.Poruke.Add(poruka);

            await _ctx.SaveChangesAsync();

            var poruke = await DajPorukeZaProizvod(poruka.proizvodId);

            return poruke;
        }

    
        public async Task<IEnumerable<Poruka>> ObrisiPoruku(int porukaId)
        {
            var poruka = await _ctx.Poruke.FirstOrDefaultAsync(c => c.Id == porukaId);

            if (poruka == null)
                throw new Exception("Poruka nije pronadjena!");

            poruka.Status = StatusPoruke.NEAKTIVNA;

            _ctx.Entry(poruka).State = EntityState.Modified;

            await _ctx.SaveChangesAsync();

            return await DajPorukeZaProizvod(poruka.proizvodId);
        }
        

    }
}
