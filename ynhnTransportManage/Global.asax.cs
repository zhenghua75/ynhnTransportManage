using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Diagnostics;

namespace ynhnTransportManage
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapRoute("NoAction", "{controller}.mvc",
           //     new { controller = "Account", action = "Logon", id = "" });//无

           // routes.MapRoute(
           //     "Default", // 路由名称
           //     "{controller}.aspx/{action}/{id}", // 带有参数的 URL
           //     new { action = "LogOn", id = UrlParameter.Optional } // 参数默认值
           // );

           // routes.MapRoute(
           //  "Root",
           //  "",
           //  new { controller = "Account", action = "LogOn", id = UrlParameter.Optional }
           //);
            //默认匹配 
            routes.MapRoute("Root", "", new { controller = "Account", action = "LogOn", id = "" });//根目录匹配 
            
            routes.MapRoute("NoID", "{controller}/{action}.aspx", new { controller = "Account", action = "Logon", id = "" });//无ID的匹配 
            routes.MapRoute("NoAction", "{controller}.aspx", new { controller = "Account", action = "Logon", id = "" });//无Action的匹配 

            routes.MapRoute("Default", "{controller}/{action}/{id}.aspx", new { controller = "Account", action = "Logon", id = "" });//默认匹配 
            


           
            //routes.MapRoute(
            //    "Root", // 路由名称
            //    "", // 带有参数的 URL
            //    new { controller = "Account", action = "LogOn", id = UrlParameter.Optional } // 参数默认值
            //);
            //routes.MapRoute(
            //    "Default", // 路由名称
            //    "{controller}.aspx/{action}/{id}", // 带有参数的 URL
            //    new { controller = "Account", action = "LogOn", id = UrlParameter.Optional } // 参数默认值
            //);
            //routes.MapRoute(
            //    "AddToRole", // 路由名称
            //    "{controller}/{action}/{userName}/{roleName}", // 带有参数的 URL
            //    new { controller = "Account", action = "AddToRole",userName= "",roleName="" } // 参数默认值
            //);
            //routes.MapRoute(
            //  "Root",
            //  "",
            //  new { controller = "Account", action = "LogOn", id = UrlParameter.Optional }
            //);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            //get reference to the source of the exception chain
            Exception ex = Server.GetLastError().GetBaseException();

            //log the details of the exception and page state to the
            //Event Log
            EventLog.WriteEntry("ynhnTransportManage",
              "MESSAGE: " + ex.Message +
              "\nSOURCE: " + ex.Source +
              "\nFORM: " + Request.Form.ToString() +
              "\nQUERYSTRING: " + Request.QueryString.ToString() +
              "\nTARGETSITE: " + ex.TargetSite +
              "\nSTACKTRACE: " + ex.StackTrace,
              EventLogEntryType.Error);

            //Optional email or other notification here...
        }
    }
}