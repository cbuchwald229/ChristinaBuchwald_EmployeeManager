using EmployeeManager.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace EmployeeManager.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(EmployeeManager.Web.Models.User userModel)
        {
            using (EmployeeManagerEntities db = new EmployeeManagerEntities())
            {
                var userDetails = db.Users.Where(x => x.username == userModel.username && x.password == userModel.password).FirstOrDefault();
                if(userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong Username or Password.";
                    return View("Index", userModel);
                }
                else
                {
                    Session["userId"] = userDetails.userId;
                    Session["username"] = userDetails.username;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userId"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}