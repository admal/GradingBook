﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GradinBookWebApp.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        // GET: Group
        //[Authorize] //add this when we do have created login and register
        public ActionResult Index()
        {
            string username = User.Identity.GetUserName();// "Adam"; //put here: User.Identity.GetUserName(); (when registration and logging is made)
            ViewBag.username = username;
            return View();
        }
    }
}