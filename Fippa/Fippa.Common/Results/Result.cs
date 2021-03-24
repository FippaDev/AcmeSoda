namespace Fippa.Common.Results
{
    public class Result
    {
        public bool Successful { get; }
        public IError Error { get; }

        protected Result(IError error)
        {
            Error = error;
            Successful = error == null;
        }

        public static Result Fail(IError error)
        {
            return new Result(error);
        }

        public static Result Success()
        {
            return new Result(null);
        }

        public static Result<T> Success<T>(T value)
        {
            return new Result<T>(value, null);
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        /// <summary>
        /// Success
        /// </summary>
        protected Result(T value)
            : base(null)
        {
            Value = value;
        }

        protected internal Result(T value, IError error)
            : base(error)
        {
            Value = value;
        }
    }
}
