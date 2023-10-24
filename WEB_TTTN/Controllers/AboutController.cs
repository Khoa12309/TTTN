using DataTTTN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB_TTTN.Controllers
{
    
    public class AboutController : Controller
    {
      
        public IActionResult AboutView()
        {
            return View();
        }
    }
}
