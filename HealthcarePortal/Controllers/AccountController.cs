using HealthcarePortal.Models;
using HealthcarePortal.Models.Data;
using HealthcarePortal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HealthcarePortal.Controllers
{
    public class AccountController : Controller
    {
        private readonly HealthcarePortalContext _db = new HealthcarePortalContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var user = new User
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                MobileNumber = viewModel.MobileNumber,
                Address = viewModel.Address,
                Password = viewModel.Password
            };
            _db.Users.Add(user);
            _db.SaveChanges();

            Roles.AddUserToRole(user.Email, "Sales");

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) return View("Unauthorized");

            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel, string returnUrl)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var user = _db.Users.FirstOrDefault(x => x.Email == viewModel.Email);
            if (user == null) ModelState.AddModelError("", "Incorrect Email id or Password");

            if (user.Password == viewModel.Password)
            {
                FormsAuthentication.SetAuthCookie(viewModel.Email, viewModel.RemeberMe);
                if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect Email id or Password");
            }

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Update()
        {
            var userEmail = User.Identity.Name;
            var user = _db.Users.FirstOrDefault(x => x.Email == userEmail);

            var viewModel = new UpdateViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNumber = user.MobileNumber,
                Address = user.Address
            };
            
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UpdateViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var user = _db.Users.FirstOrDefault(x => x.Email == User.Identity.Name);

            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.MobileNumber = viewModel.MobileNumber;
            user.Address = viewModel.Address;

            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult UserList()
        {
            var userList = _db.Users.Include(x => x.Roles).ToList().Where(x => Roles.IsUserInRole(x.Email, "Sales"));
            return View(userList);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var user = _db.Users.Find(id);
            if (user == null) return View("Error");

            _db.Users.Remove(user);
            _db.SaveChanges();

            return Json("", JsonRequestBehavior.DenyGet);
        }
    }
}