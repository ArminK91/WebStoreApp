using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using Microsoft.EntityFrameworkCore;
using WebStoreAPP.BLL.Interfaces;

namespace WebStoreAPP.BLL.ProductService
{
    public class ProductService : IProduct
    {
        readonly ApplicationDbContext _ctx;

        public ProductService(IServiceProvider serviceProvider)
        {
            _ctx = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));            
        }

        public async Task DeleteProduct(int productId, ApplicationUser user)
        {
            if (productId == null || user == null)
                throw new Exception("Nemoguce obrisati proizvod!");

           var productForDelete = _ctx.Products.Where(x => x.Id == productId && x.UserId == user.Id).FirstOrDefault();

            if (productForDelete == null)
                throw new Exception("Proizvod nije pronadjen za brisanje1");

            _ctx.Products.Remove(productForDelete);

            await _ctx.SaveChangesAsync();

        }

        public async Task<List<Product>> GetAllProductForUser(int userId)
        {
            if (userId == null)
                throw new Exception("Nemoguce vratiti proizvode za ovog korisnika!");

            var sviProizvodiKorisnika = await _ctx.Products.Where(x => x.UserId == userId).ToListAsync();

            return sviProizvodiKorisnika;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var sviProizvodi = await _ctx.Products.ToListAsync();

            return sviProizvodi;
        }

        public async Task<Product> GetProductById(int productId)
        {
            if (productId == null)
                throw new Exception("Nemoguce dohvatiti proizvod.");

            var prozivod = await _ctx.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();

            return prozivod;
        }

        public async Task<Product> SaveProduct(Product product, ApplicationUser user)
        {
            if (product == null || user == null)
                throw new Exception("Nista od spasavanja.");

            product.UserId = user.Id;

            _ctx.Products.Add(product);

            await _ctx.SaveChangesAsync();

            return product;
        }

        public Task<List<Product>> SearchProducts(string term)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> SearchProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> SerachProductsByPriceRange(decimal lowerBoundary, decimal higherBoundary)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateProduct(Product product, ApplicationUser user)
        {
            if (product == null || user == null)
                throw new Exception("Nista od spasavanja.");

            product.UserId = user.Id;

            _ctx.Entry(product).State = EntityState.Modified;


            await _ctx.SaveChangesAsync();

            return product;
        }

   
    }
}