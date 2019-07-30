using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.Common.Enumi;

namespace WebStoreAPP.BLL.HelperService
{
    public class HelperService : IHelper
    {
        readonly ApplicationDbContext _ctx;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HelperService(IServiceProvider serviceProvider, IHttpContextAccessor httpContextAccessor)
        {
            _ctx = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return new ApplicationUser(); //await _userManager.GetUserAsync(_httpContext.User);
        }

        public async Task<IList<Sifarnik>> DajTipoveProizvoda()
        {
            var tipovi = await _ctx.Sifarnik.Where(x => x.TipSif == TipSif.TIP_PROIZVODA).ToListAsync();

            return tipovi;
        }
    }
}