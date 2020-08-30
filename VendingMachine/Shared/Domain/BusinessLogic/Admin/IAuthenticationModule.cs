using Models.AdminAccess;

namespace BusinessLogic.Admin
{
    public interface IAuthenticationModule
    {
        AccessToken GetAccessToken(IAccessKey key);
    }
}