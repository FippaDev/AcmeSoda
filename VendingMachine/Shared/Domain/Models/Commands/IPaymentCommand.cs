namespace VendingMachine.Shared.Domain.Models.Commands
{
    public interface IPaymentCommand
    {
        void Execute();
        void UnExecute();
        decimal Value { get; }
    }
}