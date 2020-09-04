using System;
using System.Diagnostics.CodeAnalysis;

namespace Models.AdminAccess
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
