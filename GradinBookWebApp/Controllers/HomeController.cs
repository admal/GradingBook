using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GradinBookWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
         //add this when we do have created login and register
        [Authorize]
        [HttpGet]
        public ActionResult Index(string otherUserName = null, int? groupId = null)
        {
            //if (otherUserName == null && groupId == null)
            {
                string username = User.Identity.GetUserName();// "Adam"; //put here: User.Identity.GetUserName(); (when registration and logging is made)
                ViewBag.username = username;
                ViewBag.groupId = null;
            }
           // else
            //{
            //    ViewBag.username = otherUserName;
            //    ViewBag.groupId = groupId;
            //}
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