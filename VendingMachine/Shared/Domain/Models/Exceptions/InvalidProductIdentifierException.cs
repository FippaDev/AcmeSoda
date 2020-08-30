using System;

namespace Models.Exceptions
{
    public class InvalidProductIdentifierException : Exception
    {
        public InvalidProductIdentifierException(string message)
            : base(message)
        { }
    }
}
