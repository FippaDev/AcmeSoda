namespace VendingMachine.Shared.Domain.Models.AdminAccess
{
    public class AdminSkeletonKey : IAccessKey
    {
        public bool RequiresAuthentication
        {
            get { return false; }
        }
    }
}
