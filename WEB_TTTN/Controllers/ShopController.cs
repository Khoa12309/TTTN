using Microsoft.AspNetCore.Mvc;

namespace WEB_TTTN.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult ShopView()
        {
            return View();
        }
    }
}
