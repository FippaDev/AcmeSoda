using System;
using Ardalis.GuardClauses;

namespace VendingMachine.Shared.Domain.Models.Exceptions;

public class InvalidProductIdentifierException : Exception
{
    public InvalidProductIdentifierException(string message)
        : base(message)
    {
        Guard.Against.NullOrEmpty(message, nameof(message));
    }
}