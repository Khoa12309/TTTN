using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

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
