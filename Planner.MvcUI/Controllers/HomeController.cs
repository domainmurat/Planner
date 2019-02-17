using Planner.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISubjcetService _subjcetService;

        public HomeController(ISubjcetService subjcetService)
        {
            this._subjcetService = subjcetService;
        }
        public ActionResult Index()
        {
            var subjects = _subjcetService.GetAllList();
            ViewBag.Subjects = subjects;
            return View();
        }

        [Authorize(Roles = "Admin")]
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