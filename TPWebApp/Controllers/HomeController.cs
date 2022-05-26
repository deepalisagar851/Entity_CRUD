using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPWebApp.Model;

namespace TPWebApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.employees.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string test)
        {
            string name = Request.Form["Name"];
            string email = Request.Form["Email"];
            string salary = Request.Form["Salary"];
            string gender = Request.Form["Gender"];

            var e = new Employee()
            {
                Name = name,
                Email = email,
                Salary = Convert.ToDecimal (salary),
                Gender = gender,
            };

            db.employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var d = db.employees.Where(e => e.Id == id).SingleOrDefault();
                db.employees.Remove(d);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.employees.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
    }
}