using PersonelMVC.Models;
using PersonelMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVC.Controllers
{

    public class DepartmantController : Controller
    {
        PersonelDbContext db = new PersonelDbContext();
        // GET: Home
        public ActionResult Index()
        {
            using (PersonelDbContext db = new PersonelDbContext())
            {
                List<Departmant> lstDepartman = db.Departmants.ToList();
                return View(lstDepartman);
            }

        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("DepartmantForm", new Departmant());
        }

        [HttpPost]
        public ActionResult Save(Departmant departmant)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmantForm", departmant);
            }
            MessageViewModel message = new MessageViewModel();
            using (PersonelDbContext db = new PersonelDbContext())
            {
                if (departmant.Id == 0)
                {
                    db.Departmants.Add(departmant);
                    message.Message = $"{departmant.Name} başarıyla eklendi.";
                }

                else
                {
                    var updatedDepartmant = db.Departmants.Find(departmant.Id);
                    updatedDepartmant.Name = departmant.Name;
                    message.Message = $"{departmant.Name} başarıyla güncellendi.";
                }
                db.SaveChanges();
                message.Status = true;
                message.LinkText = "Departman Listesi";
                message.Url = "/Departmant";
            }
            return PartialView("_Message", message);
            //return RedirectToAction("Index", "Departmant");
        }
        public ActionResult Update(int id)
        {
            using (PersonelDbContext db = new PersonelDbContext())
            {
                var departmant = db.Departmants.Find(id);
                if (departmant == null)
                    return HttpNotFound();
                else
                    return View("DepartmantForm", departmant);

            }

        }
        public ActionResult Delete(int id)
        {
            using (PersonelDbContext db = new PersonelDbContext())
            {
                var departmant = db.Departmants.Find(id);
                if (departmant == null)
                    return HttpNotFound();
                else
                {
                    db.Departmants.Remove(departmant);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
        }

    }
}