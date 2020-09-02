namespace AcmeSodaConsoleApp
{
    public interface ICommandLineMenu
    {
        void Action(in string input);
        bool IsExitCommand(in string input);
        bool IsHelpCommand(in string input);
        void DisplayHelpInfo();
    }
}