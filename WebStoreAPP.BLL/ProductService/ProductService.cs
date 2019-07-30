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


           var productForDelete = _ctx.Products.Include(i => i.Auto).Where(x => x.Id == productId && x.UserId == user.Id).FirstOrDefault();

            if (productForDelete == null)
                throw new Exception("Proizvod nije pronadjen za brisanje1");

            _ctx.Products.Remove(productForDelete);

            await _ctx.SaveChangesAsync();

        }

        public async Task<List<Product>> GetAllProductForUser(int userId)
        {
            var user = _ctx.Users.FirstOrDefault(x => x.Id == userId);
            
            if (user == null)
                throw new Exception("Nemoguce vratiti proizvode za ovog korisnika, jer korisnik ne postoji!");

            var sviProizvodiKorisnika = await _ctx.Products.Include(i => i.Auto).Where(x => x.UserId == userId).ToListAsync();

            return sviProizvodiKorisnika;
        }

        public async Task<IEnumerable<Product>> GetAllProducts(string userName)
        {
            var sviProizvodi = await _ctx.Products.Include(i => i.Auto).ToListAsync();

            return sviProizvodi;
        }

        public async Task<Product> GetProductById(int productId, string userName)
        {
            if (productId == null)
                throw new Exception("Nemoguce dohvatiti proizvod.");

            var prozivod = await _ctx.Products.Include(i => i.Auto).Where(x => x.Id == productId).FirstOrDefaultAsync();

            return prozivod;
        }

        private async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Username == userName);
            return user;
        }


        public async Task<Product> SaveProduct(Product product, string userName)
        {
            if (product == null || userName == null)
                throw new Exception("Nista od spasavanja.");

            var user = await GetUserByUserName(userName);

            product.UserId = user.Id;

            _ctx.Products.Add(product);

            await _ctx.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> SearchProductsAsync(string term, Kategorija kategorija, string userName)
        {
            if (term == null || term == "")
                return null;

            var proizvodi = await _ctx.Products.Include(i => i.Auto).Where(x => x.Naziv.Contains(term)).ToListAsync();

            return proizvodi;
        }

        public async Task<List<Product>> SearchProductsByCategoryAsync(int categoryId, string userName)
        {
            if (categoryId == 0)
                return null;

            var proizvodi = await _ctx.Products.Include(i => i.Auto).Where(x => x.CategoryId == categoryId).ToListAsync();

            return proizvodi;
        }

        public async Task<List<Product>> SerachProductsByPriceRangeAsync(decimal lowerBoundary, decimal higherBoundary, string userName)
        {
            if (lowerBoundary <= 0 || higherBoundary <= 0)
                return null;

            if (lowerBoundary == higherBoundary)
            {
                return await _ctx.Products.Include(i => i.Auto).Where(x => x.Price == lowerBoundary).ToListAsync();
            }

            return await _ctx.Products.Include(i => i.Auto).Where(x => x.Price >= lowerBoundary && x.Price <= higherBoundary).ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product, string userName)
        {
            if (product == null || userName == null)
                throw new Exception("Nista od spasavanja.");

            var user = await GetUserByUserName(userName);

            product.UserId = user.Id;

            _ctx.Entry(product).State = EntityState.Modified;


            await _ctx.SaveChangesAsync();

            return product;
        }

   
    }
}