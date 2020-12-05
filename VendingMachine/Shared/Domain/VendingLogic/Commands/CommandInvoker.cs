using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Shared.Domain.DomainServices.Commands
{
    /// <summary>
    /// Command 'invoker' - a collection of commands, then processes them.
    /// </summary>
    public class CommandInvoker
    {
        private readonly List<Command> _commands = new List<Command>();

        public CommandInvoker()
        {
        }

        public void Add(Command command)
        {
            command.Execute();
            _commands.Add(command);
        }

        public void Reset()
        {
            foreach (var cmd in _commands)
            {
                cmd.UnExecute();
            }
        }

        public bool Complete()
        {
            var monies = _commands.Where(c => c is PaymentCommand).ToList();
            var products = _commands.Where(c => c is ProductCommand).ToList();

            var moniesIn = monies.Sum(c => c.Value);
            var total = products.Sum(c => c.Value);

            if (moniesIn >= total)
            {
                ApproveTransaction(monies, products);
                return true;
            }

            return false;
        }

        private void ApproveTransaction(IEnumerable<Command> monies, IEnumerable<Command> products)
        {
            // TODO: Process coins/card payments
            foreach(var cmd in monies)
            {
                cmd.Execute();
            }

            // TODO: Dispense products
            foreach(var cmd in products)
            {
                cmd.Execute();
            }
        }
    }
}
