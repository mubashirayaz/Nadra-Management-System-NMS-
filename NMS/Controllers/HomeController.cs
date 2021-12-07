using NMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NMS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(login_tbl objuser)
        {
            NadraDbContext obj = new NadraDbContext();
            var user = obj.login_tbl.Where(x => x.login_email == objuser.login_email && x.login_password == objuser.login_password);
           
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}