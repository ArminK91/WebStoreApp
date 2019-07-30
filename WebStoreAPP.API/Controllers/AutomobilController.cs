using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.Common.Mappers;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreApp.API.Controllers
{
    [Route("api/automobil")]
    [Authorize]
    public class AutomobilController : Controller
    {
        private IProduct _productService { get; set; }
        private IAutomobil _autoService { get; set; }


        public AutomobilController(IProduct productService, IAutomobil automobilService)
        {
            _productService = productService;
            _autoService = automobilService;
        }

        
        [HttpGet]
        [Route("dohvatiauta")]
        public async Task<IActionResult> DohvatiSvaAuta()
        {
            try
            {
                var automobili = await _autoService.DohvatiSveAutomobile();

                return Ok(automobili.Select(c => c.ToViewModel()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
        [HttpPost]
        [Route("snimiauto")]
        public async Task<IActionResult> SnimiAutomobil([FromBody]AutomobilViewModel automobil)
        {
            try
            {
                if(automobil == null)
                    throw new Exception("Greska auto ne moze biti null!");

                var auto = automobil.ToModel();

                var createdAuto = await _autoService.SnimiAutomobil(auto);

                return Ok(createdAuto.ToViewModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut]
        [Route("azurirajauto")]
        public async Task<IActionResult> AzurirajAuto([FromBody]AutomobilViewModel automobil)
        {
            try
            {
                if(automobil == null)
                    throw new Exception("Greska prilikom azuriranja auta!");

                var auto = automobil.ToModel();

                var updatedAuto = await _autoService.AzurirajAutomobil(auto);

                return Ok(updatedAuto.ToViewModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete]
        [Route("obrisiauto/{autoId}")]
        public async Task<IActionResult> ObrisiAuto([FromRoute] int autoId)
        {
            try
            {
                await _autoService.ObrisiAutomobil(autoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
