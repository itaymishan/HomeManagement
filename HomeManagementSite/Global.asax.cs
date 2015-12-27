using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace HomeManagementSite
{
    public class Global : HttpApplication
    {
        private string m_activeCurrency = "CAD";
        public string ActiveCurrency
        {
            get { return m_activeCurrency; }
            set { m_activeCurrency = value; }
        }


        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}