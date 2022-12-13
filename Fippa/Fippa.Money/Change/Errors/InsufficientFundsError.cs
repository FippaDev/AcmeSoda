using Fippa.Common;

namespace Fippa.Money.Change.Errors
{
    /// <summary>
    /// For when not enough money is available to make the purchase.
    /// </summary>
    public class InsufficientFundsError : IError
    {
        public decimal Requested { get; }
        public decimal Available { get; }

        public InsufficientFundsError(decimal requested, decimal available)
        {
            Requested = requested;
            Available = available;
        }
        
        public override string ToString()
        {
            return $"Requested {Requested:C} but only {Available:C} is available.";
        }
    }
}
