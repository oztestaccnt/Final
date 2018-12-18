using System.Web.Mvc;

namespace FormData.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeModel();
            //TempData.TryGetValue("Message", out message);
            model.Message = TempData["Message"]?.ToString() ?? string.Empty;

            return View(model);
        }
    }

    public class HomeModel
    {
        public string Message { get; set; }
    }
}