using System.Web.Mvc;

namespace EmployeeManager.Web.Controllers
{
    public class HomeController : Controller
    {

        // GET: /Home/  
        [HandleError]
        public ActionResult Index()
        {
            return View();
        }
    }
}