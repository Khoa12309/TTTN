using Microsoft.AspNetCore.Mvc;

namespace WEB_TTTN.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductView()
        {
            return View();
        }
    }
}
