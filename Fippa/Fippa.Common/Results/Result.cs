namespace Fippa.Common.Results
{
    public abstract class Result : IResult
    {
        public bool Successful { get; }

        protected Result(bool successful)
        {
            Successful = successful;
        }
    }

    public abstract class Result<T> : Result
    {
        public T Value { get; }

        protected Result(bool successful, T value) 
            : base(successful)
        {
            Value = value;
        }
    }
}
