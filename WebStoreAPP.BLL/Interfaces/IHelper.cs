using DomainModels.DbModels;
using System.Threading.Tasks;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IHelper
    {
        Task<ApplicationUser> GetCurrentUserAsync();
    }
}