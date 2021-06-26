using HealthcarePortal.Models;
using HealthcarePortal.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthcarePortal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PlanController : Controller
    {
        private readonly HealthcarePortalContext _db = new HealthcarePortalContext();

        public ActionResult Index()
        {
            return View(_db.Plans.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Plan plan)
        {
            if (!ModelState.IsValid) return View("Error");

            _db.Plans.Add(plan);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Modify(int id)
        {
            var plan = _db.Plans.Find(id);
            if (plan == null) return View("Error");

            return View(plan);
        }

        [HttpPost]
        public ActionResult Modify(int id, Plan plan)
        {
            var planInDb = _db.Plans.Find(id);
            _db.Entry(planInDb).CurrentValues.SetValues(plan);
            _db.SaveChanges();

            return RedirectToAction("Index", "Plan");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var plan = _db.Plans.Find(id);
            if (plan == null) return View("Error");

            _db.Plans.Remove(plan);
            _db.SaveChanges();

            return Json("", JsonRequestBehavior.DenyGet);
        }
    }
}