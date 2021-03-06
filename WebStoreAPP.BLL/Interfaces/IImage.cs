﻿using DomainModels.DbModels;
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
        Task<Image> SnimiPodatkeOSlici(string path, int productId);
        Task<Slika> DajSliku(int Id);
        Task<Slika> DajGlavnuSliku(int proizvodId);
        Task<IEnumerable<Slika>> SnimiSliku(Slika slika);
    }
}
