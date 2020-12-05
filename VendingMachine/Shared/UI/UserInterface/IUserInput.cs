using VendingMachine.Shared.Domain.Models.VendingMachine;

namespace UserInterface
{
    public interface IUserInput
    {
        void Run(IVendingMachine vendingMachine);
    }
}
