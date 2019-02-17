using Newtonsoft.Json;
using Planner.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.MvcUI.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ISubjcetService _subjcetService;

        public HomeController(ISubjcetService subjcetService)
        {
            this._subjcetService = subjcetService;
        }
        public ActionResult Index()
        {
            var children = _subjcetService.GetSubjectSchema(CurrentUser().Id);
            var childrenJson = JsonConvert.SerializeObject(children);
            ViewBag.Subjects = childrenJson;
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