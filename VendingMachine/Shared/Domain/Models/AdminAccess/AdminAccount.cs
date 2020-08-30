namespace Models.AdminAccess
{
    public class AdminAccount : IAccessKey
    {
        public bool RequiresAuthentication => true;

        public string UserToken { get; private set; }

        public AdminAccount(string userToken)
        {
            UserToken = userToken;
        }
    }
}
