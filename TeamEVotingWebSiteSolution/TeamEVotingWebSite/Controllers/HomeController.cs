using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TeamEVotingWebSite.Models;

namespace TeamEVotingWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult WelcomePage()
        {
            ViewBag.Message = "Our team welcome page.";

            var viewPath = this.ControllerContext.RouteData.Values["action"].ToString();
            ViewBag.viewPath = viewPath;
            HttpRequest req = System.Web.HttpContext.Current.Request;
            string browserName = req.Browser.Browser;
            ViewBag.browser = browserName;

            //string userIpAddress = HttpContext.Request.UserHostAddress;
            //ViewBag.ip = userIpAddress;
            string ipAddress = string.Empty;
            if (HttpContext.Request.ServerVariables["HTTP_X__FORWARDER_FOR"] != null)
            {
                ipAddress = HttpContext.Request.ServerVariables["HTTP_X__FORWARDER_FOR"].ToString();
            }
            else if (HttpContext.Request.UserHostAddress.Length != 0)
            {
                ipAddress = HttpContext.Request.UserHostAddress;
            }
            ViewBag.ip = ipAddress;

            using (TeamEVotingDBEntities teamEVotingDBEntities = new TeamEVotingDBEntities())
            {
                VisitorInfo visitorInfo = new VisitorInfo();
                List<object> list = new List<object>();
                list.Add(visitorInfo.Visited_DateTime = DateTime.Now);
                list.Add(visitorInfo.VisitorIP = ipAddress);
                list.Add(visitorInfo.VisitorBrowser = browserName);
                list.Add(visitorInfo.VisitorLandingPage = viewPath);
                list.Add(visitorInfo.User_Id = null);
                
                object[] allitems = list.ToArray();
                teamEVotingDBEntities.Database.ExecuteSqlCommand("INSERT INTO VisitorInfo(Visited_DateTime, VisitorIP, VisitorBrowser, VisitorLandingPage, User_Id) values (@p0,@p1,@p2,@p3,@p4)", allitems);
                
               

                 
            }
            
            return View();
        }

    }
}