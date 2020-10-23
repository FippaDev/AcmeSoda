using System;

namespace VendingMachine.Shared.Domain.Models.Exceptions
{
    public class InvalidProductIdentifierException : Exception
    {
        public InvalidProductIdentifierException(string message)
            : base(message)
        { }
    }
}
