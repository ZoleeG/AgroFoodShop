using Microsoft.AspNetCore.Mvc;

namespace AgroFoodShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
