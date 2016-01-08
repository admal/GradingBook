using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GradinBookWebApp.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize] add this when we do have created login and register
        public ActionResult Index()
        {

            string username = "Adam"; //put here: User.Identity.GetUserName(); (when registration and logging is made)
            ViewBag.username = username;
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
    }
}