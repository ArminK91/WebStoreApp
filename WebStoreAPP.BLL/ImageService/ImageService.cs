using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
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
    }
}
