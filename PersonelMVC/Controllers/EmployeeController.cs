using PersonelMVC.Models;
using PersonelMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        PersonelDbContext db = new PersonelDbContext();
        // GET: Person
        public ActionResult Index()
        {
            var employees = db.Employees.Include("Departmant").ToList();
            return View(employees);

        }
       
        public ActionResult Create()
        {
            EmployeeFormViewModel model = new EmployeeFormViewModel()
            {
                Departmants = db.Departmants.ToList(),
                Employee = new Employee()
            };
            return View("EmployeeForm",model);
        }

        public ActionResult Save(Employee employee)
        {
            //if(!ModelState.IsValid)
            //{
            //    EmployeeFormViewModel model = new EmployeeFormViewModel()
            //    {
            //        Departmants = db.Departmants.ToList(),
            //        Employee = employee
            //    };
            //    return View("EmployeeForm", model);
            //}
            if(employee.Id==0)
            {
                db.Employees.Add(employee);
            }
            else
            {
                db.Entry(employee).State = System.Data.Entity.EntityState.Modified;               
            }
            db.SaveChanges();
           
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            EmployeeFormViewModel model = new EmployeeFormViewModel()
            {
                Employee = db.Employees.Find(id),
                Departmants = db.Departmants.ToList()
            };
            if (model == null)
                return HttpNotFound();
            else
            {
                return View("EmployeeForm", model);
            }
        }
        public ActionResult Delete(int id)
        {
            var deletedEmployee = db.Employees.Find(id);           
            if (deletedEmployee == null)
                return HttpNotFound();
            else
            {
                db.Employees.Remove(deletedEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult GetByDepartmantId(int departmantId)
        {
            var employees = db.Employees.Where(x => x.DepartmantId == departmantId).ToList();
            return PartialView("_EmployeeList",employees);
        }

    }
}