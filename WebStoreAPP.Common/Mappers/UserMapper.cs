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
                Username = model.Username
            };
        }

        public static UserViewModel ToViewModel(this ApplicationUser model)
        {
            var user = new UserViewModel();

            user.FirstName = model.FirstName;
            user.Id = model.Id;
            user.LastName = model.LastName;
            user.Username = model.Username;

            return user;
        }
    }
}
