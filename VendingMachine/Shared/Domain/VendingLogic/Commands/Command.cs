namespace VendingMachine.Shared.Domain.VendingLogic.Commands
{
    public abstract class Command
    {
        public decimal Value { get; }

        public abstract void Execute();
        public abstract void UnExecute();

        protected Command(decimal value)
        {
            Value = value;
        }
    }
}
