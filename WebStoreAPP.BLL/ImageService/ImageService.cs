using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using Microsoft.EntityFrameworkCore;
using WebStoreAPP.BLL.Interfaces;

namespace WebStoreAPP.BLL.ImageService
{
    public class ImageService : IImage
    {
        readonly ApplicationDbContext _ctx;

        public ImageService(IServiceProvider serviceProvider)
        {
            _ctx = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
        }

        public Task<bool> DeleteImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteImagesForProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Image>> GetAllImagesForProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> SnimiPodatkeOSlici(string path, int productId)
        {
            var image = new Image();

            image.Path = path;

            _ctx.Images.Add(image);

            await _ctx.SaveChangesAsync();

            image.ProductImages.Add(new ProductImages()
            {
                ImageId = image.Id,
                ProductId = productId
            }
            );

            await _ctx.SaveChangesAsync();

            return image;
        }

        public async Task<Slika> DajSliku(int Id)
        {
            var slika = await _ctx.Slike.FirstOrDefaultAsync(x => x.Id == Id);

            return slika;
        }
    }
}
