using PersonelMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelMVC.Controllers
{
    public class SecurityController : Controller
    {
        PersonelDbContext db = new PersonelDbContext();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var validUser = db.Users.FirstOrDefault(x=>x.Name==user.Name && x.Password==user.Password);
            if (validUser == null)
            {
                ModelState.AddModelError("invalid user", "Kullanıcı adı veya şifre hatalı.");
                //ViewBag.Hata = "Kullanıcı adı veya Şifre hatalı.";
                return View();
            }

            else
            {
                FormsAuthentication.SetAuthCookie(validUser.Name, false);
                return RedirectToAction("Index", "Departmant");
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Security");
        }
    }
}