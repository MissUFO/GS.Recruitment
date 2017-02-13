using GS.Recruitment.BusinessObjects.Implementation;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace GS.Recruitment.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AntiForgeryConfig.AdditionalDataProvider = new AntiForgeryAdditionalDataProvider();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var user = JsonConvert.DeserializeObject<User>(authTicket.UserData);
                var identity = new UserCustomIdentity(user);
                var principal = new UserCustomPrincipal(identity);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
        }
    }
}
