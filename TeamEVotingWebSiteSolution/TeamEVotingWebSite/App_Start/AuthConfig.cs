using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.GoogleOAuth2;
using Microsoft.AspNet.Membership.OpenAuth;

namespace TeamEVotingWebSite
{
    public class AuthConfig
    {
        public static void RegisterAuth()
        {
            GoogleOAuth2Client clientGoog = new GoogleOAuth2Client("31967651738-cgfc66epca68r86022qnojn1t8f7mlor.apps.googleusercontent.com", "FPk1lPo1WD_VGSjxCjwqut3n");
            IDictionary<string, string> extraData = new Dictionary<string, string>();
            OpenAuth.AuthenticationClients.Add("google", () => clientGoog, extraData);
        }
    }
}