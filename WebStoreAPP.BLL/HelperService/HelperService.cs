using System;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WebStoreAPP.BLL.Interfaces;

namespace WebStoreAPP.BLL.HelperService
{
    public class HelperService : IHelper
    {
        readonly ApplicationDbContext _ctx;
        private SignInManager<ApplicationUser> _signInManager { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }
        private HttpContext _httpContext { get; set; }


        public HelperService(IServiceProvider serviceProvider)
        {
            _ctx = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(_httpContext.User);
        }
    }
}