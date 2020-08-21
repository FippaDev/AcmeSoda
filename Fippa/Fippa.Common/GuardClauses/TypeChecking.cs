using System;
using Ardalis.GuardClauses;

namespace Fippa.Common.GuardClauses
{
    // Using the same namespace will make sure your code picks up your 
    // extensions no matter where they are in your codebase.
    namespace Ardalis.GuardClauses
    {
        public static class TypeCheckingGuard
        {
            /// <summary>
            /// If the input type is not the same as the expected type, then it
            /// throws a ArgumentException.
            /// </summary>
            public static void TypeChecking(this IGuardClause guardClause, Type input, Type expected)
            {
                if (input is null)
                {
                    throw new ArgumentNullException();
                }

                if (input.FullName != expected.FullName)
                {
                    throw new ArgumentException($"Input is not of the expected type. Expected {expected.Name} Actual {input.Name}");
                }
            }
        }
    }
}
