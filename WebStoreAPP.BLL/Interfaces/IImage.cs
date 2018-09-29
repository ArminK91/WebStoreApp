using DomainModels.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IImage
    {
        Task<List<Image>> GetAllImagesForProduct(int productId);
        Task<bool> DeleteImage(int imageId);
        Task<bool> DeleteImagesForProduct(int productId);
    }
}
