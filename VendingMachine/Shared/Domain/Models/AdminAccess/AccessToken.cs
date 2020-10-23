using System;

namespace VendingMachine.Shared.Domain.Models.AdminAccess
{
    public class AccessToken
    {
        public Guid Token { get; }
        public bool IsValid => Token != Guid.Empty;
        
        public AccessToken(Guid guid)
        {
            Token = guid;
        }
    }
}
