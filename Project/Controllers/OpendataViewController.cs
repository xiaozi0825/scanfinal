using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Project.Models;
using SpeechLib;
using Microsoft.VisualBasic;
using System.Threading;

namespace Project.Controllers
{
    public class OpendataViewController : Controller
    {
        // GET: OpendataView
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LocationIndex()
        {
            return View();
        }
        public JsonResult CreateIntro(Models.LocalIntroduce Intro)
        {
            Message message = new Message();
            return Json(message.InsertIntro(Intro),JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetIntro(Models.LocalIntroduce Intro)
        {
            Message message = new Message();
            return Json(message.GetIntro(Intro), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVoice(string des)
        {
            string str = Strings.StrConv(des, Microsoft.VisualBasic.VbStrConv.SimplifiedChinese, 0x0804);
            SpeechLib.SpVoice voice = new SpVoice();
            voice.Voice = voice.GetVoices(string.Empty, string.Empty).Item(0);
            if (des!="0")
            { 
                voice.Speak(str,SpeechVoiceSpeakFlags.SVSFlagsAsync);
            }
            else
            {
                voice.Pause();
            }
            return Json("");
        }
    }
}