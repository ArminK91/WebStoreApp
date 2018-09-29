using DomainModels.DbModels;
using System.Collections.Generic;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IIdentity
    {
        ApplicationUser Authenticate(string username, string password);
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
        ApplicationUser Create(ApplicationUser user, string password);
        void Update(ApplicationUser user, string password = null);
        void Delete(int id);
    }
}