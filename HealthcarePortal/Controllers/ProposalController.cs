using HealthcarePortal.Models;
using HealthcarePortal.Models.Data;
using HealthcarePortal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HealthcarePortal.Controllers
{
    public class ProposalController : Controller
    {
        private readonly HealthcarePortalContext _db = new HealthcarePortalContext();

        [Authorize(Roles = "Sales")]
        public ActionResult Create()
        {
            var viewModel = new ProposalViewModel
            {
                AdminUser = _db.Users.Include(x => x.Roles).ToList().Where(x => Roles.IsUserInRole(x.Email, "Admin"))
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Sales")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(ProposalViewModel viewModel)
        {
            TempData["Proposal"] = viewModel.Proposal;

            int noOfEmployee = viewModel.Proposal.NumberOfEmployee;
            var employees = new List<Employee>(Enumerable.Repeat(new Employee(), noOfEmployee));

            return View(employees);
        }

        [Authorize(Roles = "Sales")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectPlan(IEnumerable<Employee> employees)
        {
            TempData["Employees"] = employees;

            var viewModel = new SelectPlanViewModel
            {
                Plans = _db.Plans.ToList()
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Sales")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveProposal(SelectPlanViewModel viewModel)
        {
            var proposal = TempData["Proposal"] as Proposal;
            var employees = TempData["Employees"] as IEnumerable<Employee>;
            
            proposal.PlanId = viewModel.PlanId;
            proposal.Employees = employees as ICollection<Employee>;
            proposal.IsApproved = false;

            _db.Proposals.Add(proposal);
            foreach (var employee in proposal.Employees)
            {
                _db.Employees.Add(employee);
            }
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult ShowProposals()
        {
            var proposalList = _db.Proposals.Include(x => x.AdminUser).Include(x => x.Plan).ToList();

            return View(proposalList);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShowProposalAdmin()
        {
            var adminEmail = User.Identity.Name;
            var proposalList = _db.Proposals.Include(x => x.AdminUser).Include(x => x.Plan).Where(x => x.AdminUser.Email == adminEmail).ToList();

            return View(proposalList);
        }

        [Authorize]
        public ActionResult EmployeeList(int id)
        {
            var proposal = _db.Proposals.Include(x => x.Employees).FirstOrDefault(x => x.Id == id);
            if (proposal == null) return View("Error");

            return PartialView("_EmployeeList", proposal.Employees);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult ApproveProposal(int id)
        {
            var proposal = _db.Proposals.Include(x => x.Employees).FirstOrDefault(x => x.Id == id);
            if (proposal == null) return View("Error");

            proposal.IsApproved = true;
            _db.SaveChanges();

            return Json("", JsonRequestBehavior.DenyGet);
        }
    }
}