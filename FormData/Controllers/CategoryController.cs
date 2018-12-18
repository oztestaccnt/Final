using System.Linq;
using System.Web.Mvc;
using FormData.DataLayer;

namespace FormData.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Product/Category
        public ActionResult Index()
        {
            // retrieve a list of all categories
            using (NorthwndEntities db = new NorthwndEntities())
            {
                return View(db.Categories.OrderBy(c => c.CategoryName).ToList());
            }
        }
    }
}