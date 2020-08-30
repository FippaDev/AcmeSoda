using System;

namespace Models.AdminAccess
{
    public class InvalidAccessToken : AccessToken
    {
        public InvalidAccessToken() 
            : base(Guid.Empty)
        {
        }
    }
}
