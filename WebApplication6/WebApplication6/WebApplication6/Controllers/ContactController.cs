using System.Web.Mvc;
using FoodWebsite.Models;

namespace FoodWebsite.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        // POST: Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                // You can add email logic here
                ViewBag.Message = "Thank you for reaching out! We will get back to you shortly.";
                ModelState.Clear();  // Clear the form after successful submission
            }
            return View(model);
        }
    }
}
