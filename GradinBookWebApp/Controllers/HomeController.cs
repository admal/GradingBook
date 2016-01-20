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
        public ActionResult Index(string username = null, int? groupId = null)
        {
            //if (otherUserName == null && groupId == null)
            {
                string currUser = User.Identity.GetUserName();// "Adam"; //put here: User.Identity.GetUserName(); (when registration and logging is made)
                ViewBag.username = currUser;
                ViewBag.groupId = null;
            }
           // else
            //{
            //    ViewBag.username = otherUserName;
            //    ViewBag.groupId = groupId;
            //}
            return View();
        }

        public ActionResult Settings()
        {
            ViewBag.username = User.Identity.GetUserName();
            return View();
        }
    }
}