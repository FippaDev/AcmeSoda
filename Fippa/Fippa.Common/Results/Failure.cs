using Ardalis.GuardClauses;

namespace Fippa.Common.Results
{
    public class Failure : IResult
    {
        public bool Successful => false;
        public IError Error { get; }

        public Failure(IError error) 
        {
            Guard.Against.Null(error, nameof(error), "Failures must specify the error");
            Error = error;
        }
    }
}