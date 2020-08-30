namespace VendingLogic.Admin.Commands
{
    public interface ICommandController
    {
        void ExecuteCommand(ICommand command);
    }
}