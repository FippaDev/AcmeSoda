using System;

namespace Fippa.Common.Results
{
    public class Result
    {
        public bool Successful { get; }
        public bool Failed => !Successful;
        public IError Error { get; }

        protected Result(bool success, IError error)
        {
            Successful = success;
            Error = error;

            if (Successful && error != null)
            {
                throw new InvalidOperationException("It cannot be successful and have an error.");
            }

            if (Failed && error == null)
            {
                throw new InvalidOperationException("It cannot be unsuccessful without an error.");
            }
        }

        public static Result Fail(IError error)
        {
            return new Result(false, error);
        }

        public static Result<T> Fail<T>(IError<T> error)
        {
            return new Result<T>(default(T), false, error);
        }

        public static Result Success()
        {
            return new Result(true, null);
        }

        public static Result<T> Success<T>()
        {
            return new Result<T>(default(T), true, null);
        }
    }

    public class Result<T> : Result
    {
        private readonly T _value;
        public T Value {
            get
            {
                if (Failed)
                {
                    throw new InvalidOperationException("Failed results don't have values.");
                }

                return _value;
            }
        }

        protected internal Result(T value, bool success, IError error)
            : base(success, error)
        {
            _value = value;
        }
    }
}
