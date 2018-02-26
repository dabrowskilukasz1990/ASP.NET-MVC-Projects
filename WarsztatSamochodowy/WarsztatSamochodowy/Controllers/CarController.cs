using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WarsztatSamochodowy.Context;
using WarsztatSamochodowy.Models;

namespace WarsztatSamochodowy.Controllers
{
    public class CarController : Controller
    {
        private WarsztatSamochodowyDbContext db = new WarsztatSamochodowyDbContext();

        // GET: Car
        public ActionResult Index()
        {
            var car = db.car.Include(c => c.Employee);
            return View(car.ToList());
        }

        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.employee, "EmployeeId", "LastName");

            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,RegisterNumber,VinNumber,Brand,Model,ResponsiblePerson,TaskList,DateOfReceipt,Price,CarErrorMessage,EmployeeId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.car.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.employee, "EmployeeId", "LastName", car.EmployeeId);
            return View(car);
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.employee, "EmployeeId", "LastName", car.EmployeeId);
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarId,RegisterNumber,VinNumber,Brand,Model,ResponsiblePerson,TaskList,DateOfReceipt,Price,CarErrorMessage,EmployeeId")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.employee, "EmployeeId", "LastName", car.EmployeeId);
            return View(car);
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.car.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.car.Find(id);
            db.car.Remove(car);
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
