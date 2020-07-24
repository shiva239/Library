using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public MVCEntities db = new MVCEntities();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            db.Registers.Add(register);
            int i = db.SaveChanges();
            if (i>0)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View(register);
            }
            
        }

        public ActionResult Login()
        {
            return View();
        }

    }
}