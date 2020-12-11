using System;
using Ardalis.GuardClauses;

namespace Fippa.Common.GuardClauses
{
    // Using the same namespace will make sure your code picks up your 
    // extensions no matter where they are in your codebase.
    namespace Ardalis.GuardClauses
    {
        public static class ExpressionBeingFalseGuard
        {
            /// <summary>
            /// Throws an exception is the input is false
            /// </summary>
            public static void ExpressionBeingFalse(this IGuardClause guardClause, bool expression, string parameterName)
            {
                Guard.Against.Null(guardClause, nameof(guardClause));

                if (expression == false)
                {
                    throw new ArgumentException("False inputs are not allowed", parameterName);
                }
            }
        }
    }
}
