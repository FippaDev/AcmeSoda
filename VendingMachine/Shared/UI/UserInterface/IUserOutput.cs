namespace UserInterface
{
    public interface IUserOutput
    {
        void ShowBalance(decimal balance);
        void ShowWelcomeMessage(string manufacturer);
        void Message(string s);
    }
}
