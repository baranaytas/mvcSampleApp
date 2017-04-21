using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Bus;
using Publisher_web.App_Start;

namespace Publisher_web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfiguration.Configure();
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
