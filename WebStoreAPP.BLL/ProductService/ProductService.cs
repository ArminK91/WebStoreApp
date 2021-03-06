using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using Microsoft.EntityFrameworkCore;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.Common.Enumi;

namespace WebStoreAPP.BLL.ProductService
{
    public class ProductService : IProduct
    {
        readonly ApplicationDbContext _ctx;

        public ProductService(IServiceProvider serviceProvider)
        {
            _ctx = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));            
        }
        public async Task DeleteProduct(int productId, string userName)
        {
            if (userName == null)
                throw new Exception("Nemoguce obrisati proizvod!");

           var user = await GetUserByUserName(userName);

           var productForDelete = _ctx.Proizvodi
               .Include(i => i.Slike)
               .Where(x => x.Id == productId && x.UsrId == user.Id)
               .FirstOrDefault();

            if (productForDelete == null)
                throw new Exception("Proizvod nije pronadjen za brisanje1");

            var auto = await _ctx.Automobili.FirstOrDefaultAsync(x => x.ProizvId == productForDelete.Id);

            productForDelete.Status = StatusSloga.NEAKTIVAN;
            auto.Status = StatusSloga.NEAKTIVAN;

            _ctx.Entry(productForDelete).State = EntityState.Modified;
            _ctx.Entry(auto).State = EntityState.Modified;

            await _ctx.SaveChangesAsync();
        }
        public async Task<IEnumerable<Proizvod>> OkoncajProizvod(int productId, string user)
        {
            var proizvod = await _ctx.Proizvodi.FirstOrDefaultAsync(x => x.Id == productId);

            proizvod.StatusProizvoda = StatusProizvoda.OKONCAN;

            _ctx.Entry(proizvod).State = EntityState.Modified;

            await _ctx.SaveChangesAsync();

            return await GetAllProductForUser(user);
        }

        public async Task<List<Proizvod>> GetAllProductForUser(string userName)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Username == userName);
            
            if (user == null)
                throw new Exception("Nemoguce vratiti proizvode za ovog korisnika, jer korisnik ne postoji!");

            var sviProizvodiKorisnika = await _ctx.Proizvodi
                                                  .Include(i => i.Auto)
                                                  .Include(i => i.Slike)
                                                  .Where(x => x.UsrId == user.Id && x.Status == StatusSloga.AKTIVAN)
                                                  .ToListAsync();
            return sviProizvodiKorisnika;
        }

        public async Task<IEnumerable<Proizvod>> GetAllProducts(string userName)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(c => c.Username == userName);
            var sviProizvodi = 
                                await _ctx.Proizvodi
                                          .Include(i => i.Auto)
                                          .Include(i => i.Slike)
                                          .Include(i => i.User)
                                          .Where(x => x.Status == StatusSloga.AKTIVAN && x.StatusProizvoda == StatusProizvoda.AKTIVAN)
                                          .ToListAsync();
            return sviProizvodi;
        }

        public async Task<Proizvod> GetProductById(int productId, string userName)
        {
            var prozivod = await _ctx.Proizvodi
                .Include(i => i.Auto)
                .Include(i => i.Slike)
                .Include(i => i.User)
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync();

            var auto = await _ctx.Automobili.Where(x => x.ProizvId == productId).FirstOrDefaultAsync();
            var slike = await _ctx.Slike.Where(x => x.ProizvodId == productId).ToListAsync();

            prozivod.Auto = auto;
            prozivod.Slike = slike;

            return prozivod;
        }

        private async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            var user = await _ctx.Users
                .FirstOrDefaultAsync(x => x.Username == userName);
            return user;
        }

        public async Task<Proizvod> SaveProduct(Proizvod product, string userName)
        {
            if (product == null || userName == null)
                throw new Exception("Nista od spasavanja.");

            var user = await GetUserByUserName(userName);

            product.UsrId = user.Id;
            product.Status = StatusSloga.AKTIVAN;
            product.Objavio = userName;
            product.StatusProizvoda = StatusProizvoda.AKTIVAN;
            product.DatumObjave = DateTime.Now;

            _ctx.Proizvodi.Add(product);

            await _ctx.SaveChangesAsync();

            return product;
        }

        public async Task<List<Proizvod>> SearchProductsAsync(string term, Kategorija kategorija, string userName)
        {
            if (term == null || term == "")
                return null;

            var proizvodi = await _ctx.Proizvodi
                .Include(i => i.Auto)
                .Include(i => i.Slike)
                .Where(x => x.Naziv.Contains(term))
                .ToListAsync();

            return proizvodi;
        }

        public async Task<List<Proizvod>> SearchProductsByCategoryAsync(int categoryId, string userName)
        {
            if (categoryId == 0)
                return null;

            var proizvodi = await _ctx.Proizvodi
                .Include(i => i.Auto)
                .Include(i => i.Slike)
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();

            return proizvodi;
        }

        public async Task<List<Proizvod>> SerachProductsByPriceRangeAsync(decimal lowerBoundary, decimal higherBoundary, string userName)
        {
            if (lowerBoundary <= 0 || higherBoundary <= 0)
                return null;

            if (lowerBoundary == higherBoundary)
            {
                return await _ctx.Proizvodi
                    .Include(i => i.Auto)
                    .Include(i => i.Slike)
                    .Where(x => x.Price == lowerBoundary)
                    .ToListAsync();
            }

            return await _ctx.Proizvodi
                .Include(i => i.Auto)
                .Include(i => i.Slike)
                .Where(x => x.Price >= lowerBoundary && x.Price <= higherBoundary)
                .ToListAsync();
        }

        public async Task<Proizvod> UpdateProduct(Proizvod product, string userName)
        {
            if (product == null || userName == null)
                throw new Exception("Nista od spasavanja.");

            var user = await GetUserByUserName(userName);

            product.UsrId = user.Id;

            _ctx.Entry(product).State = EntityState.Modified;

            await _ctx.SaveChangesAsync();

            return product;
        }
    }
}