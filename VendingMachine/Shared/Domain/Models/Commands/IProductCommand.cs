namespace VendingMachine.Shared.Domain.Models.Commands
{
    public interface IProductCommand
    {
        void Execute();
        void UnExecute();
        decimal Value { get; }
    }
}