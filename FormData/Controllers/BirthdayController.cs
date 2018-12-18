using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FormData.Controllers
{
    public class BirthdayController : Controller
    {
        // Data acquired from external source (eg. Database)
        string[] balloons = { "Red", "Blue", "Green", "Purple" };


        public ActionResult Index()
        {

            // create an array of strings
            // "put" the array in the ViewBag
            ViewBag.balloons = balloons;

            return View();
        }


        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            List<string> balloonList = new List<string>();

            ViewBag.ResultName = form["name"];
            ViewBag.ResultBD = form["birthday"];

            foreach (var balloon in balloons)
            {
                var b = form[balloon].Split(',');      // true,false
                var val = b[0];       // not quite correct - look at debugger
                bool isChecked = Convert.ToBoolean(val);

                if (isChecked)          // if balloon checkbox is true
                {
                    balloonList.Add(balloon);  // add name of balloon
                }
            }
            ViewBag.BalloonList = balloonList;  // save list of checked balloons

            return View("Results");
        }

    }
}