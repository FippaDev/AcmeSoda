using System.Collections.Generic;

namespace VendingMachine.Shared.Services
{
    public interface IUserOutput
    {
        void ShowBalance(decimal balance);
        void ShowWelcomeMessage(string manufacturer);
        void Message(string s);
        void Show(IEnumerable<string> lines);
    }
}
