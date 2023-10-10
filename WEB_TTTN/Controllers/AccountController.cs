using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class AccountController : Controller
    {
        private Getapi<Account> getapi;
        private Getapi<User> getapiUser;

        public AccountController()
        {
            getapi = new Getapi<Account>();
            getapiUser = new Getapi<User>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Account");
            return View(obj);
        }

       
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            
            return View();
        }

     
        [HttpPost]
        public async Task<IActionResult> Create(Account obj)
        {
            try
            {
              

                getapi.CreateObj(obj, "Account");
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]

       
        public async Task<IActionResult> Edit(Guid id)
        {

            var lst =  getapi.GetApi("Account");
            return View(lst.Find(c => c.Id == id));
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(Account obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Account");
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }

        //// GET: SupplierController1/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            getapi.DeleteObj(id, "Account");
            return RedirectToAction("GetList");

        }
    }
}
