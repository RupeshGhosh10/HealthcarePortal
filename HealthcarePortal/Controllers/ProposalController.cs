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
    [Authorize(Roles = "Sales")]
    public class ProposalController : Controller
    {
        private readonly HealthcarePortalContext _db = new HealthcarePortalContext();

        public ActionResult Create()
        {
            var viewModel = new ProposalViewModel
            {
                AdminUser = _db.Users.Include(x => x.Roles).ToList().Where(x => Roles.IsUserInRole(x.Email, "Admin"))
            };

            return View(viewModel);
        }
    }
}