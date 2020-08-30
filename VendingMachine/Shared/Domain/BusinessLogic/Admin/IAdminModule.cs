using Models.AdminAccess;

namespace BusinessLogic.Admin
{
    public interface IAdminModule
    {
        void SignIn(IAccessKey key);
        void SignOut();
    }
}
