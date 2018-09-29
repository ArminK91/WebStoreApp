using DomainModels.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using WebStoreAPP.Common.ViewModels;

namespace WebStoreAPP.Common.Mappers
{
    public static partial class Mappers
    {
        public static ApplicationUser ToModel(this UserViewModel model)
        {
            return new ApplicationUser()
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Username = model.Username,
            };
        }

        public static UserViewModel ToViewModel(this ApplicationUser model)
        {
            return new UserViewModel()
            {
                FirstName = model.FirstName,
                Id = model.Id,
                LastName = model.LastName,
                Username = model.Username
            };
        }
    }
}
