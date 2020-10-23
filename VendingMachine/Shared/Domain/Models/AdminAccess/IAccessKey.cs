namespace VendingMachine.Shared.Domain.Models.AdminAccess
{
    public interface IAccessKey
    {
        bool RequiresAuthentication { get; }
    }
}
