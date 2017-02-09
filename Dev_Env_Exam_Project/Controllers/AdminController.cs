using Dev_Env_Exam_Project.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



namespace Dev_Env_Exam_Project.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        //public actionresult index()
        //{
        //    return view();
        //}
        private ApplicationDbContext context = new ApplicationDbContext();
        [Authorize(Users = "admin@gmail.com")]
        //give Admin role to the authenticated user
        public ActionResult RegisterAdmin(string userName)
        {
            //Add Admin role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string role = "Admin";
            //Create Role Admin if it does not exist
            if (!roleManager.RoleExists(role))
            {
                var roleResult = roleManager.Create(new IdentityRole(role));
            }

            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var userManager = new UserManager<ApplicationUser>(store);
            ApplicationUser currentUser = userManager.FindByNameAsync(User.Identity.Name).Result;
            //string userId = User.Identity.GetUserId();
            var result = userManager.AddToRole(userName, "Admin");

            if (Roles.IsUserInRole("Admin"))
            {
                ViewBag.userrole = "Admin";
            }
            else
            {
                ViewBag.userrole = "Unassigned";
            }
            return View();
        }
    }
}