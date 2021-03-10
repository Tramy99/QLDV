using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLDV.Models;

namespace QLDV.Controllers
{
    public class HoatDongsController : Controller
    {
        private QLDVConnect db = new QLDVConnect();

        // GET: HoatDongs
        public ActionResult Index()
        {
            return View(db.HoatDongs.ToList());
        }

        // GET: HoatDongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoatDong hoatDong = db.HoatDongs.Find(id);
            if (hoatDong == null)
            {
                return HttpNotFound();
            }
            return View(hoatDong);
        }

        // GET: HoatDongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HoatDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mahd,madv,tenhd,thoigiantc,ghichu")] HoatDong hoatDong)
        {
            if (ModelState.IsValid)
            {
                db.HoatDongs.Add(hoatDong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hoatDong);
        }

        // GET: HoatDongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoatDong hoatDong = db.HoatDongs.Find(id);
            if (hoatDong == null)
            {
                return HttpNotFound();
            }
            return View(hoatDong);
        }

        // POST: HoatDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mahd,madv,tenhd,thoigiantc,ghichu")] HoatDong hoatDong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoatDong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hoatDong);
        }

        // GET: HoatDongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoatDong hoatDong = db.HoatDongs.Find(id);
            if (hoatDong == null)
            {
                return HttpNotFound();
            }
            return View(hoatDong);
        }

        // POST: HoatDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoatDong hoatDong = db.HoatDongs.Find(id);
            db.HoatDongs.Remove(hoatDong);
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
