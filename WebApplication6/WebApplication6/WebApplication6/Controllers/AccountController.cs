using System.Web.Mvc;
using FoodWebsite.Models;

namespace FoodWebsite.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Simulate authentication (you can replace with real authentication)
                if (model.Email == "admin@foodwebsite.com" && model.Password == "password123")
                {
                    // Redirect to home after successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View(model);
        }
    }
}
