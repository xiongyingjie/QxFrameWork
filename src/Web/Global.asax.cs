using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Ioc.Unity;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityIoc.Register(typeof(Controller).GetSubClasses());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
