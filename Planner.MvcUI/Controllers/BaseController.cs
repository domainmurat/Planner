using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Planner.DataAccess.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.MvcUI.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public User CurrentUser()
        {
            return  System.Web.HttpContext.Current.GetOwinContext()
                .GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId()); ;
        }
    }
}