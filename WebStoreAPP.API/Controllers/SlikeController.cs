using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DomainModels.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebStoreApp.API.Helpers;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreApp.API.Controllers
{
    [Authorize]
    [Route("api/proizvodi/{proizvodId}/slike")]
    public class SlikeController : Controller
    {
        private readonly IProduct _productService;
        private readonly IImage _imageService;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly IMapper _mapper;
        private Cloudinary _cloudinary;

        public SlikeController(IProduct productService, IImage imageService,
            IOptions<CloudinarySettings> cloudinaryConfig, IMapper mapper)
        {
            _productService = productService;
            _imageService = imageService;
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        [HttpGet]
        [Route("dajsliku{id}")]
        public async Task<IActionResult> DajSliku(int Id)
        {
            var slika = await _imageService.DajSliku(Id);

            var slikaVM = _mapper.Map<SlikaZaKreiranjeDto>(slika);

            return Ok(slikaVM);
        }

        [HttpPost]
        public async Task<IActionResult> DodajSlikuZaProizvod(int productId, SlikaZaKreiranjeDto slika)
        {
            var file = slika.File;

            var uploadResults = new ImageUploadResult();

            var proizvod = await _productService.GetProductById(productId, User.Identity.Name);

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill")
                    };

                    uploadResults = _cloudinary.Upload(uploadParams);

                }
            }

            slika.Url = uploadResults.Uri.ToString();
            slika.PublicId = uploadResults.PublicId;

            var slikaDb = _mapper.Map<Slika>(slika);

            if (!proizvod.Slike.Any(v => v.Glavna))
            {
                slikaDb.Glavna = true;
            }

            proizvod.Slike.Add(slikaDb);


            var prod = await _productService.UpdateProduct(proizvod, User.Identity.Name);

            if (prod != null && prod.Slike.Any() == true)
            {
                var slikaZaVratiti = _mapper.Map<SlikaDetaljiDto>(slikaDb);

                return CreatedAtRoute("DajSliku", new {Id = slikaDb.Id}, slikaZaVratiti);
            }

            return BadRequest("Greska prilikom dodavanja slike!");
        }
    }

}
