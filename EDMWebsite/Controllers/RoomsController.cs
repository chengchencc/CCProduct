using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EDMWebsite;
using EDMWebsite.Models.DbModels;

namespace EDMWebsite.Controllers
{
    public class RoomsController : BaseController
    {
        private WriteableSqlDbContext db = new WriteableSqlDbContext();

        // GET: Rooms
        public ActionResult Index()
        {
            Dictionary<string, string> breadcrumbs = new Dictionary<string, string>();
            breadcrumbs.Add("", "房间信息");
            ViewData["Breadcrumbs"] = breadcrumbs;

            var model = db.Rooms.ToList();
            return View(model);
        }

        public ActionResult Test()
        {
            var room = db.Rooms.Find(4);
            var build = db.Buildings.ToList()[0];//.Find(1);
            room.Building = build;
            db.Entry(room).State = EntityState.Modified;
            db.SaveChanges();
            var rrr = db.Rooms.Find(4).Building;
            return Content("success");
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            BindBuildingSelectList();
            BindInstituteSelectList();
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,Type,Area,Status,BuildingId,InstituteId")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            BindBuildingSelectList();
            BindInstituteSelectList();
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,Type,Area,Status,BuildingId,InstituteId")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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

        #region Helpers
        private void BindBuildingSelectList()
        {
            var buildings = db.Buildings.ToList();
            var buildingSelectList = new List<SelectListItem>();
            foreach (var item in buildings)
            {
                var selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.Id.ToString();
                buildingSelectList.Add(selectListItem);
            }
            ViewData["Buildings"] = buildingSelectList;
        }

        private void BindInstituteSelectList()
        {
            var institutes = db.Institutes.ToList();
            var instituteSelectList = new List<SelectListItem>();
            foreach (var item in institutes)
            {
                var selectListItem = new SelectListItem();
                selectListItem.Text = item.Name;
                selectListItem.Value = item.Id.ToString();
                instituteSelectList.Add(selectListItem);
            }
            ViewData["Institutes"] = instituteSelectList;
        }

        #endregion
    }
}
