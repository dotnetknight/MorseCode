using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MorseCode.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace MorseCode.Controllers
{
    public class HomeController : Controller
    {
        public static string Data = "";
        public static string dt = "";
        //https://blog.trackduck.com/2015/06/10/15-impressive-pop-animation-effects-codepen/

        public ActionResult Index() { return View(); }
        public ActionResult a() { return View(); }

        [HttpGet]
        public ActionResult b() { return View(); }

        [HttpPost]
        public ActionResult b(string cars)
        {
            /*
            int a = Convert.ToInt32(Request.Form["val1"]);
            int b = Convert.ToInt32(Request.Form["val2"]);
            int func = 2;

            if (a != null) { func = a; }
            else if (b != null) { func = b; }
            if (func != 2) { ViewBag.msg = func; return RedirectToAction("Index", "Home"); }

             */
            return View();
        }

        [HttpPost]
        public JsonResult PostMethod(string name, int DeValue)
        {
            int OptionValue = 3;
            OptionValue = DeValue;

            if (ModelState.IsValid)
            {
                string url = "";

                if (OptionValue != 3)
                {
                    if (OptionValue == 1) { url = "http://www.morsecode-api.de/encode?string=" + name; }
                    else if (OptionValue == 2) { url = "http://www.morsecode-api.de/decode?string=" + name; }
                }

                string JSonString = "";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        { JSonString = reader.ReadToEnd(); reader.Close(); stream.Close(); }
                    }
                }

                var MorseData = JsonConvert.DeserializeObject<RootObject>(JSonString);

                if (OptionValue == 1) { Data = MorseData.morsecode; }
                else if (OptionValue == 2) { Data = MorseData.plaintext; }
                PersonModel person = new PersonModel { Name = Data };

                return Json(person);
            }
            else { ModelState.AddModelError("Val", "Value must be present"); return Json("", JsonRequestBehavior.AllowGet); }
        }


        /*
        public ActionResult Index(SetData txt)
        {
            /*
            if (ModelState.IsValid)
            {
                string url = "http://www.morsecode-api.de/encode?string=" + txt.Text;
                string JSonString = "";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        { JSonString = reader.ReadToEnd(); reader.Close(); stream.Close(); }
                    }
                }

                var MovieData = JsonConvert.DeserializeObject<RootObject>(JSonString);
                Data = MovieData.morsecode;
                dt = MovieData.plaintext;
            }
            else { ModelState.AddModelError("TxtVal", "TXT is required"); }
            
            return View();
        }
 */
    }
}