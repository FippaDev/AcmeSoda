using Models.AdminAccess;

namespace VendingLogic.Admin
{
    public interface IAuthenticationModule
    {
        AccessToken GetAccessToken(IAccessKey key);
    }
}