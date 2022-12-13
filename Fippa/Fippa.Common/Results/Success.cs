namespace Fippa.Common.Results
{
    public class Success : Result
    {
        public Success()
            : base(true)
        {
        }
    }

    public class Success<T> : Result<T>
    {
        public Success(T value)
            : base(true, value)
        {
        }
    }
}