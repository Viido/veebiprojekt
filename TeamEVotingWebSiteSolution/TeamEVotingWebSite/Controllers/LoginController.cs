using DotNetOpenAuth.GoogleOAuth2;
using Microsoft.AspNet.Membership.OpenAuth;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TeamEVotingWebSite.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            //Call https://www.google.com/accounts/Logout if you want to logoff at provider
            return Redirect(Url.Action("Index", "Home"));
        }
        public ActionResult RedirectToGoogle()
        {
            string provider = "google";
            string returnUrl = "";
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }
        
        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            string ProviderName = OpenAuth.GetProviderNameFromCurrentRequest();

            if (ProviderName == null || ProviderName == "")
            {
                NameValueCollection nvs = Request.QueryString;
                if (nvs.Count > 0)
                {
                    if (nvs["state"] != null)
                    {
                        NameValueCollection provideritem = HttpUtility.ParseQueryString(nvs["state"]);
                        if (provideritem["__provider__"] != null)
                        {
                            ProviderName = provideritem["__provider__"];
                        }
                    }
                }
            }

            GoogleOAuth2Client.RewriteRequest();

            var redirectUrl = Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl });
            var retUrl = returnUrl;
            var authResult = OpenAuth.VerifyAuthentication(redirectUrl);

            if (!authResult.IsSuccessful)
            {
                return Redirect(Url.Action("Login", "Login"));
            }

            ViewBag.authResultName = authResult.UserName;
            ViewBag.authResultProvider = authResult.Provider;
            ViewBag.authResultProviderUserId = authResult.ProviderUserId;
            ViewBag.authResultEmail = authResult.ExtraData["email"];
            
            // tuleb lisada kasutaja andmebaasi kirjutamine
        
            return View();
        }
        
        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OpenAuth.RequestAuthentication(Provider, ReturnUrl);
            }
        }
        
    }
}