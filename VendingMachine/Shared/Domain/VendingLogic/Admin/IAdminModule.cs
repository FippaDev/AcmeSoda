using VendingMachine.Shared.Domain.Models.AdminAccess;

namespace VendingMachine.Shared.Domain.VendingLogic.Admin
{
    public interface IAdminModule
    {
        void SignIn(IAccessKey key);
        void SignOut();
    }
}
