using System;

namespace Models.AdminAccess
{
    public class AdminAccessToken : AccessToken
    {
        public AdminAccessToken()
         : base(Guid.Empty)
        {
        }
    }
}
