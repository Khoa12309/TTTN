using DataTTTN.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEB_TTTN.Models;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Getapi<User> getapiUser;
        private Getapi<Account> getapiAcc;
        private Getapi<Role> getapiRole;
        private Getapi<Phanvung> getapiPV;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;           
            getapiUser = new Getapi<User>();
            getapiAcc = new Getapi<Account>();
            getapiRole = new Getapi<Role>();
            getapiPV = new Getapi<Phanvung>();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;
            if (claimsUser.Identity.IsAuthenticated)
                return RedirectToAction("Index");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email_username, string password)
        {
            var Acc =  getapiAcc.GetApi("Account").FirstOrDefault(c => c.Email == email_username && c.Password == password);
            var _user = getapiUser.GetApi("User").FirstOrDefault(c => c.Id == Acc.Id_User);
            var _pv = getapiPV.GetApi("Phanvung").FirstOrDefault(c => c.Id_User == _user.Id);
            string _role="";
            if (_pv != null)
            {
                 _role = getapiRole.GetApi("Role").FirstOrDefault(c => c.Id == _pv.Id_Role).Name;
               
            }
           
            SessionService.SetObjToJson(HttpContext.Session, "User", _user);

            if (Acc != null)
            {
                List<Claim> claims = new List<Claim>()
                  {
                      new Claim(ClaimTypes.NameIdentifier,email_username),
                      new Claim(ClaimTypes.Role,_role)
                  };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index");
            }
            else
                return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Dangki()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Dangki(string email, string password)
        {
            var user = new User()
            {
                Fullname = "",
                Email = email,
                Dateofbirth = DateTime.Now,
                PhoneNumber = "",
                Point = 0,
                Status = 1,
                Gender = 0,
                Id = Guid.NewGuid(),
            };
            var acc = new Account()
            {
                Email = email,
                Password = password,
                Id_User = user.Id,
                Status = user.Status,
                Id = Guid.NewGuid(),
            };


            var User = getapiUser.CreateObj(user, "User");
            var Acc = getapiAcc.CreateObj(acc, "Account");



            return RedirectToAction("Login");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}