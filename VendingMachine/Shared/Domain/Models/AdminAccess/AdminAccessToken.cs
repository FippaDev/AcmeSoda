using System;
using System.Diagnostics.CodeAnalysis;

namespace VendingMachine.Shared.Domain.Models.AdminAccess
{
    [ExcludeFromCodeCoverage]
    public class AdminAccessToken : AccessToken
    {
        public AdminAccessToken()
         : base(Guid.Empty)
        {
        }
    }
}
