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
            GoogleOAuth2Client clientGoog = new GoogleOAuth2Client("117580050702-8crrsbahd612scj7mmattdj4q6shdneg.apps.googleusercontent.com", "1PEiScjOjxCuUMoqs5BCizmM");
            IDictionary<string, string> extraData = new Dictionary<string, string>();
            OpenAuth.AuthenticationClients.Add("google", () => clientGoog, extraData);
        }
    }
}