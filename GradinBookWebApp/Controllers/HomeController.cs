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
        [Authorize]
        [HttpGet]
        public ActionResult Index(string username = null, int? groupId = null)
        {
            if (username == null && groupId == null) //it means user is looking into his own profile
            {
                string currUser = User.Identity.GetUserName();// "Adam"; //put here: User.Identity.GetUserName(); (when registration and logging is made)
                ViewBag.username = currUser;
                ViewBag.groupId = null;
            }
            else //user is watching other user's prfile
            {
                ViewBag.username = username;
                ViewBag.groupId = groupId;
            }
            return View();
        }

        public ActionResult Settings()
        {
            ViewBag.username = User.Identity.GetUserName();
            return View();
        }
    }
}