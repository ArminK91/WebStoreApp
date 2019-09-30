using AutoMapper;
using DomainModels.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreApp.API.Controllers;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreApp.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>();
            CreateMap<UserViewModel, ApplicationUser>();

            CreateMap<SlikaZaKreiranjeDto, Slika>();
            CreateMap<Slika, SlikaZaKreiranjeDto>();

            CreateMap<SlikaDetaljiDto, Slika>();
            CreateMap<Slika, SlikaDetaljiDto>();
        }
    }
}
