using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebStoreAPP.BLL.Interfaces;

namespace WebStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class GeneralController : Controller
    {
        private IHelper _helper;

        public GeneralController(IHelper helperService)
        {
            _helper = helperService;
        }

        [HttpGet]
        [Route("tipovi")]
        public async Task<IActionResult> DajTipoveProizvoda()
        {
            try
            {
                var tipoviProizvoda = await _helper.DajTipoveProizvoda();
                return Ok(tipoviProizvoda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
