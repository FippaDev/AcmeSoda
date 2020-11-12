using System;
using Ardalis.GuardClauses;

namespace Fippa.Common.GuardClauses
{
    // Using the same namespace will make sure your code picks up your 
    // extensions no matter where they are in your codebase.
    namespace Ardalis.GuardClauses
    {
        public static class PositiveOrZeroGuard
        {
            /// <summary>
            /// Throws an exception is the input is false
            /// </summary>
            public static void PositiveOrZero(this IGuardClause guardClause, decimal input, string parameterName)
            {
                Guard.Against.Null(guardClause, nameof(guardClause));

                if (input >= 0)
                {
                    throw new ArgumentException("Input must be negative", parameterName);
                }
            }
        }
    }
}
