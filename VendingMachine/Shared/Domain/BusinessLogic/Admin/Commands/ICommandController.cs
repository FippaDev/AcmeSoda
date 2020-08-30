namespace BusinessLogic.Admin.Commands
{
    public interface ICommandController
    {
        void ExecuteCommand(ICommand command);
    }
}