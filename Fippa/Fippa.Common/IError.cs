namespace Fippa.Common
{
    public interface IError
    {
    }

    public interface IError<out T> : IError
    {
        T Value { get; }
    }
}
