using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CC.Product.Models.CarPooling;
using Microsoft.AspNet.Identity;

namespace CC.Product.Website.Controllers
{
    public class CarpoolingController : Controller
    {
        private DBContext db = new DBContext();

        // GET: CarpoolingInfoes
        public ActionResult Index()
        {
            return View(db.CarpoolingInfos.ToList());
        }

        // GET: CarpoolingInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarpoolingInfo carpoolingInfo = db.CarpoolingInfos.Find(id);
            if (carpoolingInfo == null)
            {
                return HttpNotFound();
            }
            return View(carpoolingInfo);
        }

        // GET: CarpoolingInfoes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarpoolingInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,No,StartSite,Destination,DateTime,CreateTime,PublishUserId,TotalSeatCount,HasCar,Price,Comment,PassingBySite")] CarpoolingInfo carpoolingInfo)
        {
            if (ModelState.IsValid)
            {
                carpoolingInfo.PublishUserId = User.Identity.GetUserId();
                carpoolingInfo.CreateTime = DateTime.Now;

                db.CarpoolingInfos.Add(carpoolingInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carpoolingInfo);
        }

        // GET: CarpoolingInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarpoolingInfo carpoolingInfo = db.CarpoolingInfos.Find(id);
            if (carpoolingInfo == null)
            {
                return HttpNotFound();
            }
            return View(carpoolingInfo);
        }

        // POST: CarpoolingInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,No,StartSite,Destination,DateTime,CreateTime,PublishUserId,TotalSeatCount,HasCar,Price,Comment,PassingBySite")] CarpoolingInfo carpoolingInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carpoolingInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carpoolingInfo);
        }

        // GET: CarpoolingInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarpoolingInfo carpoolingInfo = db.CarpoolingInfos.Find(id);
            if (carpoolingInfo == null)
            {
                return HttpNotFound();
            }
            return View(carpoolingInfo);
        }

        // POST: CarpoolingInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarpoolingInfo carpoolingInfo = db.CarpoolingInfos.Find(id);
            db.CarpoolingInfos.Remove(carpoolingInfo);
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