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
    [Route("api/proizvodislike")]
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
                "dfxrccfyu",
                "555938815487972",
                "LiVqyZ5d52u6N4Ug4JM-fvKoi7Y"
            );

            _cloudinary = new Cloudinary(acc);
        }

        [HttpGet]
        [Route("{id}", Name = "DajSliku")]
        public async Task<IActionResult> DajSliku([FromRoute]int Id)
        {
            var slika = await _imageService.DajSliku(Id);

            var slikaVM = _mapper.Map<SlikaZaKreiranjeDto>(slika);

            return Ok(slikaVM);
        }

        [HttpPost]
        [Route("dodajslikuzaproizvod/{productId}")]
        public async Task<IActionResult> DodajSlikuZaProizvod([FromRoute]int productId, [FromForm]SlikaZaKreiranjeDto slika)
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
            slika.ProizvodId = proizvod.Id;

            var slikaDb = _mapper.Map<Slika>(slika);

            proizvod.Slike.Add(slikaDb);

            var prod = await _productService.UpdateProduct(proizvod, User.Identity.Name);

            if (prod != null && prod.Slike.Any() == true)
            {
                var slikaZaVratiti = _mapper.Map<SlikaDetaljiDto>(slikaDb);

                return CreatedAtRoute("DajSliku", new {Id = slikaDb.Id}, slikaZaVratiti);
            }

            return BadRequest("Greska prilikom dodavanja slike!");
        }

        [HttpPost("{proizvodId}/postaviglavnu/{id}")]
        public async Task<IActionResult> PostaviZaGlavnu(int proizvodId, int id)
        {
            var product = await _productService.GetProductById(proizvodId, User.Identity.Name);

            if (!product.Slike.Any(p => p.Id == id))
            {
                return Unauthorized();
            }

            var slika = await _imageService.DajSliku(id);

            if (slika.Glavna)
                BadRequest("Ovo je vec glavna slika!");

            var trenutnaGlavnaSlika = await _imageService.DajGlavnuSliku(proizvodId);

            if (trenutnaGlavnaSlika != null)
            { 
                trenutnaGlavnaSlika.Glavna = false;
            }

            slika.Glavna = true;

            var slike = await _imageService.SnimiSliku(slika);

            return Ok(_mapper.Map<List<SlikaDetaljiDto>>(slike));
        }
    }

}
