namespace Fippa.Common
{
    public interface IError
    {
        string ToString();
    }

    public interface IError<out T> : IError
    {
        T Value { get; }
    }
}
