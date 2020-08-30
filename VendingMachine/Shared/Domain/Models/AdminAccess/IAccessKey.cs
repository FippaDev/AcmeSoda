namespace Models.AdminAccess
{
    public interface IAccessKey
    {
        bool RequiresAuthentication { get; }
    }
}
