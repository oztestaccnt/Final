using System;
using System.Linq;
using System.Web.Mvc;
using FormData.DataLayer;

namespace FormData.Controllers
{
    public class DiscountController : Controller
    {
        // GET: Product/Discount
        public ActionResult Index()
        {
            // retrieve a list of discounts 
            using (NorthwndEntities db = new NorthwndEntities())
            {
                // Filter by date
                DateTime now = DateTime.Now;
                return View(db.Discounts.Where(s => s.StartTime <= now && s.EndTime > now).ToList());
            }
        }
    }
}