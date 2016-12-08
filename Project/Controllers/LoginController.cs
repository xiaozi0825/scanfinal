using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin(string UserAccount, string UserPassword)
        {
            Models.Login Login = new Models.Login();
            ViewBag.result = Login.SearchUser(UserAccount, UserPassword);
            return this.Json(ViewBag.result);
        }

        public ActionResult UpdateUser(string UserAccount)
        {
            Models.SearchUserData SearchUserData = new Models.SearchUserData();
            ViewBag.UserData = SearchUserData.searchuserData(UserAccount);
            return View();
        }

        public ActionResult UpdateUserdata(Models.UserDetail User)
        {
            Models.SearchUserData UpdateUserData = new Models.SearchUserData();
            UpdateUserData.UpdateUserData(User);
            return RedirectToAction("Index");
        }
    }
}