using Microsoft.AspNetCore.Mvc;

namespace WEB_TTTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
