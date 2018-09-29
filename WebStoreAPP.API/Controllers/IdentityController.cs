using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DomainModels.DbModels;
using DomainModels.Other;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebStoreAPP.BLL.Interfaces;
using WebStoreAPP.Common.Mappers;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.API.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {

        private IIdentity _identityService { get; set; }
        private readonly AppSettings _appSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityController(IIdentity identityService, IOptions<AppSettings> appSettings, SignInManager<ApplicationUser> signInManager,
           UserManager<ApplicationUser> userManager)
        {
            _identityService = identityService;
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserViewModel userDto)
        {
            var user = _identityService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]UserViewModel userDto)
        {
            // map dto to entity
            var user = userDto.ToModel();

            //var rezult = await _userManager.CreateAsync(user, userDto.Password);
            _identityService.Create(user, userDto.Password);
            //if(rezult.Succeeded)
                return Ok();
           //return BadRequest(rezult.Errors);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = _identityService.GetAll();
            var userDtos = users.Select(x => x.ToViewModel());
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = _identityService.GetById(id);
            var userDto = user.ToViewModel();
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody]UserViewModel userDto)
        {
            // map dto to entity and set id
            var user = userDto.ToModel();
            user.Id = id;

            try
            {
                // save 
                _identityService.Update(user, userDto.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _identityService.Delete(id);
            return Ok();
        }
    }
}