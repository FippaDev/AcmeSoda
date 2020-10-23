using VendingMachine.Shared.Domain.Domain.VendingMachine;

namespace UserInterface
{
    public interface IUserInput
    {
        void Run(IVendingMachine vendingMachine);
    }
}
