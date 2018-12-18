using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormData.DataLayer;

namespace FormData.Controllers
{
    public class ChartController : Controller
    {

        NorthwndEntities context = new NorthwndEntities();

        // GET: Chart
        public ActionResult GetData()
        {
            int country = context.Customers.Where(m => m.Country == "USA").Count();
            int country1 = context.Customers.Where(m => m.Country == "Mexico").Count();
            int country2 = context.Customers.Where(m => m.Country == "Germany").Count();
            int country3 = context.Customers.Where(m => m.Country == "Argentina").Count();
            int country4 = context.Customers.Where(m => m.Country == "Austria").Count();
            int country5 = context.Customers.Where(m => m.Country == "France").Count();
            int country6 = context.Customers.Where(m => m.Country == "UK").Count();
            int country7 = context.Customers.Where(m => m.Country == "Brazil").Count();

            Ratio obj = new Ratio();
            obj.USA = country;
            obj.Mexico = country1;
            obj.Germany = country2;
            obj.Argentina = country3;
            obj.Austria = country4;
            obj.France = country5;
            obj.UK = country6;
            obj.Brazil = country7;

            // return Json(obj, JsonRequestBehavior.AllowGet);
            return View(obj);
        }

        public class Ratio
        {
            public int USA { get; set; }
            public int Mexico { get; set; }
            public int Germany { get; set; }
            public int Argentina { get; set; }
            public int Austria { get; set; }
            public int Brazil { get; set; }
            public int France { get; set; }
            public int UK { get; set; }

        }
    }
}