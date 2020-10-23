namespace VendingMachine.Shared.Domain.Models.AdminAccess
{
    public class AdminAccount : IAccessKey
    {
        public bool RequiresAuthentication => true;

        public string UserToken { get; }

        public AdminAccount(string userToken)
        {
            UserToken = userToken;
        }
    }
}
