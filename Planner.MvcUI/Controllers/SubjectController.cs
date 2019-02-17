using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Planner.Business.Abstract;
using Planner.DataAccess.Context;
using Planner.DataAccess.PlannerAggregate;
using Planner.MvcUI.Helper;

namespace Planner.MvcUI.Controllers
{
    [Authorize]
    public class SubjectController : BaseController
    {
        private readonly ISubjcetService _subjcetService;

        public SubjectController(ISubjcetService subjcetService)
        {
            this._subjcetService = subjcetService;
        }

        // GET: Subject
        public ActionResult Index()
        {
            //var Subject = db.Subject.Include(s => s.ParentSubject).Include(s => s.User);
            var subjects = _subjcetService.GetAllListWithoutDeleted();
            return View(subjects);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            var subjects = _subjcetService.GetAllListWithoutDeleted();
            List<SelectListItem> selectListItems = DropDownHelper.ToSelectListItem(subjects);
            ViewBag.ParentSubjectId = selectListItems;
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Detail,ParentSubjectId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.UserId = CurrentUser().Id;
                _subjcetService.Add(subject);
                return RedirectToAction("Index");
            }

            var subjects = _subjcetService.GetAllListWithoutDeleted();
            List<SelectListItem> selectListItems = DropDownHelper.ToSelectListItem(subjects);
            ViewBag.ParentSubjectId = new SelectList(selectListItems, "Value", "Text", subject.ParentSubjectId);

            return View(subject);
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = _subjcetService.GetById(id.GetValueOrDefault());
            if (subject == null)
            {
                return HttpNotFound();
            }
            var subjects = _subjcetService.GetAllListWithoutDeleted(x => x.Id != id);
            List<SelectListItem> selectListItems = DropDownHelper.ToSelectListItem(subjects);
            ViewBag.ParentSubjectId = new SelectList(selectListItems, "Value", "Text", subject.ParentSubjectId);

            return View(subject);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Detail,ParentSubjectId")] Subject subject)
        {
            if (ModelState.IsValid)
            {

                _subjcetService.ChangeParent(subject, CurrentUser().Id);
                return RedirectToAction("Index");
            }

            var subjects = _subjcetService.GetAllListWithoutDeleted(x => x.Id != subject.Id);
            List<SelectListItem> selectListItems = DropDownHelper.ToSelectListItem(subjects);
            ViewBag.ParentSubjectId = new SelectList(selectListItems, "Value", "Text", subject.ParentSubjectId);

            return View(subject);
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = _subjcetService.GetById(id.GetValueOrDefault());
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _subjcetService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
