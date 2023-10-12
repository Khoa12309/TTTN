using Microsoft.AspNetCore.Mvc;

namespace WEB_TTTN.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Cart()
        {

            return View();
        }
    }
}
