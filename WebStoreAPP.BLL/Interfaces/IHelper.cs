using DomainModels.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IHelper
    {
        Task<ApplicationUser> GetCurrentUserAsync();
        Task<IList<Sifarnik>> DajTipoveProizvoda();
    }
}