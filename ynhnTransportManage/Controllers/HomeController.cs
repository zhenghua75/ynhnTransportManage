using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Permissions;

namespace ynhnTransportManage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        //[Authorize(Users="zhenghua")]
        //[PrincipalPermission(SecurityAction.Demand,Authenticated=true,Name="test",Role="Admin",Unrestricted="false")]
        //[PrincipalPermission(SecurityAction.Demand, Role = "Administrator")]
        //[ControllerAction]
        public ActionResult About()
        {
            return View();
        }

        
    }
}
