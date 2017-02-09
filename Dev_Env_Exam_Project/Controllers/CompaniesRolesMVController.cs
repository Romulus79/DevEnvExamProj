using Dev_Env_Exam_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dev_Env_Exam_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompaniesRolesMVController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: CompaniesRoles
        public ActionResult Index()
        {
            CompanyRoleViewModel mymodel = new CompanyRoleViewModel();
            mymodel.Companies = db.Companies.ToList();
            mymodel.Roles = db.Roles.ToList();
            return View(mymodel);
        }
    }
}