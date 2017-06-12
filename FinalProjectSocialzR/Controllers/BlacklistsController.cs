using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProjectSocialzR.Models;

namespace FinalProjectSocialzR.Controllers
{
    public class BlacklistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blacklists
        public ActionResult Index()
        {
            return View(db.Blacklists.ToList());
        }

        public ActionResult GetAfter300()
        {
            var vm = db.Blacklists.ToList();

            return PartialView("_blacklistPartial", vm);
        }
        
        // GET: Blacklists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blacklist blacklist = db.Blacklists.Find(id);
            if (blacklist == null)
            {
                return HttpNotFound();
            }
            return View(blacklist);
        }

        // GET: Blacklists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blacklists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Word")] Blacklist blacklist)
        {
            if (ModelState.IsValid)
            {
                db.Blacklists.Add(blacklist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blacklist);
        }

        // GET: Blacklists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blacklist blacklist = db.Blacklists.Find(id);
            if (blacklist == null)
            {
                return HttpNotFound();
            }
            return View(blacklist);
        }

        // POST: Blacklists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Word")] Blacklist blacklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blacklist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blacklist);
        }

        // GET: Blacklists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blacklist blacklist = db.Blacklists.Find(id);
            if (blacklist == null)
            {
                return HttpNotFound();
            }
            return View(blacklist);
        }

        // POST: Blacklists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blacklist blacklist = db.Blacklists.Find(id);
            db.Blacklists.Remove(blacklist);
            db.SaveChanges();
            var vm = db.Blacklists.ToList();
            return PartialView(vm);
        }

        [HttpDelete]
        public ActionResult DeleteWord(int id)
        {
            Blacklist blacklist = db.Blacklists.Find(id);
            db.Blacklists.Remove(blacklist);
            db.SaveChanges();

            var vm = db.Blacklists.ToList();
            return PartialView("_blacklistPartial", vm);
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
