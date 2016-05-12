using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using School.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace School.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        //
        // GET: /Roles/
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }
        // GET: Roles
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string roleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string RoleName)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ManageUserRoles()
        {
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(ro => new SelectListItem { Value = ro.Name.ToString(), Text = ro.Name }).ToList();
            ViewBag.Roles = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            if (UserName != "" && RoleName != "")
            {
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                if (user == null)
                {
                    ViewBag.Message = "Wrong username!";
                    return View("ErrorNoUnAndRn");
                }

                userManager.AddToRole(user.Id, RoleName);


                ViewBag.ResultMessage = "Role created successfully!";

                // prepopulat roles for the view dropdown
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(ro => new SelectListItem { Value = ro.Name.ToString(), Text = ro.Name }).ToList();
                ViewBag.Roles = list;

            }
            else
            {
                ViewBag.Message = "Username and Role Name is required!";
                return View("ErrorNoUnAndRn");
            }

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                if (user == null)
                {
                    ViewBag.Message = "Wrong username!";
                    return View("ErrorNoUnAndRn");
                }

                ViewBag.RolesForThisUser = userManager.GetRoles(user.Id);

                // prepopulat roles for the view dropdown
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(ro => new SelectListItem { Value = ro.Name.ToString(), Text = ro.Name }).ToList();
                ViewBag.Roles = list;
            }
            else
            {
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(ro => new SelectListItem { Value = ro.Name.ToString(), Text = ro.Name }).ToList();
                ViewBag.Roles = list;
                ViewBag.MessageGet = "Въведи username!";
            }
            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            if (UserName != "" && RoleName != "")
            {
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                if (user == null)
                {
                    ViewBag.Message = "Wrong username!";
                    return View("ErrorNoUnAndRn");
                }

                if (userManager.IsInRole(user.Id, RoleName))
                {
                    userManager.RemoveFromRole(user.Id, RoleName);
                    ViewBag.ResultМессаге = "Role removed from this user successfully!";
                }
                else
                {
                    ViewBag.ResultMessage = "This user doesn't belong to selected role.";
                }

                // prepopulat roles for the view dropdown
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(ro => new SelectListItem { Value = ro.Name.ToString(), Text = ro.Name }).ToList();
                ViewBag.Roles = list;

            }
            else
            {
                ViewBag.Message = "Username and Role Name is required!";
                return View("ErrorNoUnAndRn");
            }

            return View("ManageUserRoles");
        }
    }
}