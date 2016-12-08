using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Project.Models;
namespace Project.Controllers
{
    public class IntroductionController : Controller
    {
        // GET: Introduction
        public ActionResult IntroductionIndex()
        {
            return View();
        }
        public ActionResult InsertIndex(Models.Introduction introduce)
        {
            return View();
        }
        public ActionResult InsertLocation(Models.Introduction introduce)
        {
            Models.Introduce Introduce = new Models.Introduce();
            Introduce.UserRegister(introduce);
            return RedirectToAction("../Introduction/InsertIndex");
        }

        public ActionResult getIntroduction()
        {
            Models.Introduce Introduction = new Models.Introduce();
            ViewBag.result = Introduction.SearchIntroduction();
            return this.Json(ViewBag.result);
        }

      
    }
}