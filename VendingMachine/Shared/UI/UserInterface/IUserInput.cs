using VendingMachine.Shared.Domain.Models.VendingMachine;

namespace UserInterface
{
    public interface IUserInput
    {
        void SetVendingMachineType(IVendingMachine vendingMachine);
        void Run();
    }
}
