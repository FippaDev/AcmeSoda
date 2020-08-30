using BusinessLogic.Admin.Commands;
using Models.AdminAccess;

namespace BusinessLogic.Admin
{
    public class AdminModule : IAdminModule
    {
        private readonly IAuthenticationModule _authenticationModule;
        private readonly ICommandController _commandController;
        
        private AccessToken _accessToken = new InvalidAccessToken();

        public AdminModule(
            IAuthenticationModule authenticationModule,
            ICommandController commandController)
        {
            _authenticationModule = authenticationModule;
            _commandController = commandController;
        }

        public void SignIn(IAccessKey key)
        {
            _accessToken = _authenticationModule.GetAccessToken(key);
        }

        public void SignOut()
        {
            _accessToken = new InvalidAccessToken();
        }

        public void ExecuteCommand(ICommand command)
        {
            _commandController.ExecuteCommand(command);
        }
    }
}
