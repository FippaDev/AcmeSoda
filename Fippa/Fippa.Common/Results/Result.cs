using System;
using Ardalis.GuardClauses;
using Fippa.Common.GuardClauses.Ardalis.GuardClauses;

namespace Fippa.Common.Results
{
    public class Result
    {
        public bool Successful { get; }
        public bool Failed => !Successful;
        public IError Error { get; }

        protected Result(bool success, IError error)
        {
            Guard.Against.ExpressionBeingTrue(success && error != null, "Results cannot be successful and have an error.");
            Guard.Against.ExpressionBeingTrue(!success && error == null, "Results cannot be unsuccessful without an error.");

            Successful = success;
            Error = error;
        }

        public static Result Fail(IError error)
        {
            return new Result(false, error);
        }

        public static Result Success()
        {
            return new Result(true, null);
        }

        public static Result<T> Success<T>(T value)
        {
            return new Result<T>(value, true, null);
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        protected internal Result(T value, bool success, IError error)
            : base(success, error)
        {
            Value = value;
        }
    }
}
