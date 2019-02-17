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

namespace Planner.MvcUI.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        private readonly ISubjcetService subjcetService;

        public SubjectController(ISubjcetService subjcetService)
        {
            this.subjcetService = subjcetService;
        }

        // GET: Subject
        public ActionResult Index()
        {
            //var Subject = db.Subject.Include(s => s.ParentSubject).Include(s => s.User);
            var Subject = subjcetService.GetAllList();
            return View(Subject);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            ViewBag.ParentSubjectId = new SelectList(subjcetService.GetAllList(), "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
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
                subject.UserId= Request.GetOwinContext().Authentication.User
                db.Subject.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentSubjectId = new SelectList(db.Subject, "Id", "Name", subject.ParentSubjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", subject.UserId);
            return View(subject);
        }

        // GET: Subject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentSubjectId = new SelectList(db.Subject, "Id", "Name", subject.ParentSubjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", subject.UserId);
            return View(subject);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Detail,ParentSubjectId,UserId,CreatedDate,UpdatedDate,DeletedDate,CreatedUser,UpdatedUser,DeletedUser,Deleted")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentSubjectId = new SelectList(db.Subject, "Id", "Name", subject.ParentSubjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", subject.UserId);
            return View(subject);
        }

        // GET: Subject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
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
            Subject subject = db.Subject.Find(id);
            db.Subject.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
