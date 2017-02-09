using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dev_Env_Exam_Project.Models;
using System.Collections;

namespace Dev_Env_Exam_Project.Controllers
{
    [Authorize(Users = "admin@gmail.com")]
    public class CompanyController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Address,PhoneNo,Email")] Company company)
        {
            if (ModelState.IsValid)
            {
                //company.CompanyId = 1;
                //Employee employee = new Employee();
                //List<Employee> list = new List<Employee>();
                //employee.EmployeeId = 1;
                //employee.CompanyId = 1;
                //employee.Name = "some employee";
                //employee.email = "email";
                //employee.Address = "address";
                //employee.Phone = "12345678";
                //list.Add(employee);
                //company.Employees = list;
                //Role role = new Role();
                //List<Role> roles = new List<Role>();
                //role.RoleId = 1;
                //role.CompanyId = 1;
                //role.Name = "some role";
                //role.Description = "some descr";
                //roles.Add(role);
                //company.Roles = roles;
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index", "CompaniesRolesMV");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Address,PhoneNo,Email")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "CompaniesRolesMV");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index", "CompaniesRolesMV");
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
