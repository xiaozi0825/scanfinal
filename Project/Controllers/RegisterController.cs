using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register(Models.UserDetail User)
        {
            Models.Register Register = new Models.Register();
            Register.UserRegister(User);
            return RedirectToAction("../Login/Index");
        }
        public ActionResult checkRegister(string RegisterUserAccount)
        {
            Models.Register Register = new Models.Register();
            ViewBag.result = Register.checkUserAccount(RegisterUserAccount).Count;
            return this.Json(ViewBag.result);
        }
    }
}