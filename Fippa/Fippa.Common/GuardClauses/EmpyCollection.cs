using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace Fippa.Common.GuardClauses
{
    // Using the same namespace will make sure your code picks up your 
    // extensions no matter where they are in your codebase.
    namespace Ardalis.GuardClauses
    {
        public static class EmptyCollectionGuard
        {
            /// <summary>
            /// Throws an exception is the input is false
            /// </summary>
            public static void EmptyCollection<T>(this IGuardClause guardClause, IEnumerable<T> input, string parameterName)
            {
                Guard.Against.Null(guardClause, nameof(guardClause));

                var enumerable = input as T[] ?? input.ToArray();
                Guard.Against.Null(enumerable, nameof(input));

                if (!enumerable.Any())
                {
                    throw new ArgumentException("Empty collections are not allowed", parameterName);
                }
            }
        }
    }
}
