using System;
using Ardalis.GuardClauses;

namespace Fippa.Common.GuardClauses
{
    // Using the same namespace will make sure your code picks up your 
    // extensions no matter where they are in your codebase.
    namespace Ardalis.GuardClauses
    {
        public static class FalseGuard
        {
            /// <summary>
            /// Throws an exception is the input is false
            /// </summary>
            public static void False(this IGuardClause guardClause, bool input, string parameterName)
            {
                if (input == false)
                {
                    throw new ArgumentException("False inputs are not allowed", parameterName);
                }
            }
        }
    }
}
