using System;

namespace VendingMachine.Shared.Domain.Models.AdminAccess
{
    public class InvalidAccessToken : AccessToken
    {
        public InvalidAccessToken() 
            : base(Guid.Empty)
        {
        }
    }
}
