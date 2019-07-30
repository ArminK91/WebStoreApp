using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using Microsoft.EntityFrameworkCore;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.Common.Enumi;

namespace WebStoreAPP.BLL.AutomobilService
{
    public class AutomobilService : IAutomobil
    {
        readonly ApplicationDbContext _ctx;
        public AutomobilService(IServiceProvider serviceProvider)
        {
            _ctx = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
        }
        public async Task<IEnumerable<Automobil>> DohvatiSveAutomobile()
        {
            var automobili = await _ctx.Automobili.ToListAsync();
            return automobili;
        }

        public async Task<IEnumerable<Product>> DohvatiAutomobileZaUsera(string userName)
        {
            var user = _ctx.Users.FirstOrDefaultAsync(x => x.Username == userName);

            var proizvodi = await _ctx.Products.Include(i => i.Auto).Where(x => x.UserId == user.Id && x.CategoryId == (int) Kategorija.Auta && x.Status == true).ToListAsync();

            return proizvodi.AsEnumerable();
        }

        public async Task<Automobil> SnimiAutomobil(Automobil automobil)
        {
            if (automobil == null)
                throw new Exception("Greska prilikom spasavanja automobila!");

            _ctx.Automobili.Add(automobil);

            await _ctx.SaveChangesAsync();

            return automobil;
        }

        public async Task<Automobil> AzurirajAutomobil(Automobil automobil)
        {
            if (automobil == null)
                throw new Exception("Greska prilikom spasavanja automobila!");

            var auto = await _ctx.Automobili.FirstOrDefaultAsync(x => x.Id == automobil.Id);

            _ctx.Entry(auto).State = EntityState.Modified;

            await _ctx.SaveChangesAsync();

            return auto;
        }

        public async Task<bool> ObrisiAutomobil(int automobilId)
        {
            var auto = await _ctx.Automobili.FirstOrDefaultAsync(x => x.Id == automobilId);
            var proizvod = await _ctx.Products.FirstOrDefaultAsync(x => x.Id == auto.ProizvodId);

            auto.Status = (int)StatusSloga.NEAKTIVAN;
            proizvod.Status = false;

            _ctx.Entry(proizvod).State = EntityState.Modified;
            _ctx.Entry(auto).State = EntityState.Modified;

            await _ctx.SaveChangesAsync();

            return true;
        }
    }
}
