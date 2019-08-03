using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.Common.Mappers;
using WebStoreAPP.Common.ViewModels;
using System.Net.Http.Headers;

namespace WebStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PorukeController : Controller
    {
        private readonly IPoruke _porukeService;

        public PorukeController(IPoruke porukeService)
        {
            _porukeService = porukeService;
        }

        [HttpGet]
        [Route("dohvatiporukezaproizvod/{proizvodId}")]
        public async Task<IActionResult> DohvatiPorukeZaProizvod(int proizvodId)
        {
            try
            {
                var por = await _porukeService.DajPorukeZaProizvod(proizvodId);

                return Ok(por.Select(x => x.ToViewModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("snimiporuku")]
        public async Task<IActionResult> SnimiPorukuZaProizvod([FromBody] PorukaViewModel poruka)
        {
            try
            {
                var poruke = await _porukeService.SnimiPorukuZaProizvod(poruka.ToModel(), User.Identity.Name);

                return Ok(poruke.Select(c => c.ToViewModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("obrisi/{porukaId}")]
        public async Task<IActionResult> ObrisiPoruku(int porukaId)
        {
            try
            {
                var poruke = await _porukeService.ObrisiPoruku(porukaId);

                return Ok(poruke.Select(x => x.ToViewModel()));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
