
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel;


namespace Microsoft.Samples.TokenProvider
{
    public class MyUserNameSecurityTokenManager : ClientCredentialsSecurityTokenManager
    {
        MyUserNameClientCredentials myUserNameClientCredentials;
        private readonly string _userNameTokenType = "http://schemas.microsoft.com/ws/2006/05/identitymodel/tokens/UserName";

        public MyUserNameSecurityTokenManager(MyUserNameClientCredentials myUserNameClientCredentials)
            : base(myUserNameClientCredentials)
        {
            this.myUserNameClientCredentials = myUserNameClientCredentials;
        }

        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
        {
            // if token requirement matches username token return custom username token provider
            // otherwise use base implementation
            if (tokenRequirement.TokenType == _userNameTokenType)
            {
                return new MyUserNameTokenProvider();
            }
            else
            {
                return base.CreateSecurityTokenProvider(tokenRequirement);
            }
        }
    }
}

