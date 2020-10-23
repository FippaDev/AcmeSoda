using VendingMachine.Shared.Domain.Models.AdminAccess;

namespace VendingMachine.Shared.Domain.VendingLogic.Admin
{
    public interface IAuthenticationModule
    {
        AccessToken GetAccessToken(IAccessKey key);
    }
}