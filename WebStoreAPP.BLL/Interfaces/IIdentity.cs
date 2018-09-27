using DomainModels.DbModels;

namespace WebStoreAPP.BLL.Interfaces
{
    public interface IIdentity
    {
         ApplicationUser GetUserById(int userId);
    }
}