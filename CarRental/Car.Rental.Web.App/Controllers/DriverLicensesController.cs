﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Car.Rental.Web.App.Extensions;
using Car.Rental.Web.App.Models;
using Car.Rental.Web.App.Models.DataAccessLayer;

namespace Car.Rental.Web.App.Controllers
{
    public class DriverLicensesController : Controller
    {
        private CarRentalDbContext db = new CarRentalDbContext();

        // GET: DriverLicenses
        public ActionResult Index(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                searchString = "";
            }
            var driverLicenses = db.DriverLicenses
                .Where(r => r.IdentificationNumber.Contains(searchString)
                    || r.Issuer.Contains(searchString));

            return View(driverLicenses.ToList());
        }

        // GET: DriverLicenses/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverLicense driverLicense = db.DriverLicenses.Find(id);
            if (driverLicense == null)
            {
                return HttpNotFound();
            }
            return View(driverLicense);
        }

        // GET: DriverLicenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriverLicenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdentificationNumber,ValidUntil,Issuer")] DriverLicense driverLicense)
        {
            var error = string.Empty;

            if (ModelState.IsValid)
            {
                try
                {
                    driverLicense.Id = Guid.NewGuid();
                    db.DriverLicenses.Add(driverLicense);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    error = ex.GetDeepestMessage();
                }
            }

            ViewBag.Error = error;

            return View(driverLicense);
        }

        // GET: DriverLicenses/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverLicense driverLicense = db.DriverLicenses.Find(id);
            if (driverLicense == null)
            {
                return HttpNotFound();
            }
            return View(driverLicense);
        }

        // POST: DriverLicenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdentificationNumber,ValidUntil,Issuer")] DriverLicense driverLicense)
        {
            var error = string.Empty;

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(driverLicense).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    error = ex.GetDeepestMessage();
                }
            }

            ViewBag.Error = error;

            return View(driverLicense);
        }

        // GET: DriverLicenses/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverLicense driverLicense = db.DriverLicenses.Find(id);
            if (driverLicense == null)
            {
                return HttpNotFound();
            }
            return View(driverLicense);
        }

        // POST: DriverLicenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            DriverLicense driverLicense = db.DriverLicenses.Find(id);
            db.DriverLicenses.Remove(driverLicense);
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
