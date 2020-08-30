using System;
using System.Collections.Generic;
using Models.AdminAccess;

namespace VendingLogic.Admin
{
    public class AuthenticationModule : IAuthenticationModule
    {
        private readonly Dictionary<IAccessKey, AccessToken> _allowedTokens = new Dictionary<IAccessKey, AccessToken>();

        public AuthenticationModule()
        {
            _allowedTokens.Add(new AdminSkeletonKey(), new AccessToken(new Guid("{32E6FA17-D0E8-4E51-A9E7-0BAA1C9CF28D}")));
        }

        public AccessToken GetAccessToken(IAccessKey key)
        {
            if (!key.RequiresAuthentication)
            {
                return new AdminAccessToken();
            }

            return
                _allowedTokens.ContainsKey(key)
                    ? _allowedTokens[key]
                    : new InvalidAccessToken();
        }
    }
}
