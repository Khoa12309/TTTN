using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Net.Http;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class UserController : Controller
    {
        private Getapi<Account> getapiAcc;
        private Getapi<User> getapi;
        private Getapi<Role> getapiRole;
        private Getapi<Phanvung> getapiPV;

        public UserController()
        {
            getapiAcc = new Getapi<Account>();
            getapi = new Getapi<User>();
            getapiRole = new Getapi<Role>();
            getapiPV = new Getapi<Phanvung>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj =  getapi.GetApi("User");
            return View(obj);
        }

        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Acc =  getapiAcc.GetApi("Account");
            ViewBag.Role = getapiRole.GetApi("Role");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(User obj,string password,string myList)
        {
            try
            {
                //nhận dữ liệu từ from bằng javascript
                List<string> myIntList = JsonConvert.DeserializeObject<List<string>>(myList);


                obj.Id = Guid.NewGuid();
                var acc = new Account()
                {
                    Email =obj.Email,
                    Password = password,
                    Id_User =obj.Id,
                    Status =obj.Status,
                    Id = Guid.NewGuid(),
                };
                var phanquyen = new Phanvung()
                {
                    Id_User=obj.Id,
                };
                getapi.CreateObj(obj, "User");
                getapiAcc.CreateObj(acc, "Account");
                foreach (var item in myIntList)
                {
                    phanquyen.Id = Guid.NewGuid();
                    phanquyen.Note = "";
                    phanquyen.Id_Role = Guid.Parse(item);

                    getapiPV.CreateObj(phanquyen, "Phanvung");
                }
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
            
            var lst =  getapi.GetApi("User");
            ViewBag.Acc = getapiAcc.GetApi("Account").FirstOrDefault(c => c.Id_User == id).Password;
            return View(lst.Find(c => c.Id == id));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(User obj,string password)
        {
            try
            {
                var lst = getapiAcc.GetApi("Account").FirstOrDefault(c=>c.Id_User==obj.Id);
                lst.Password = password;
                getapiAcc.UpdateObj(lst, "Account");
                getapi.UpdateObj(obj, "User");
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
            getapi.DeleteObj(id, "User");
            return RedirectToAction("GetList");

        }

        [HttpPost]
        public ActionResult MyAction(string myList)
        {
            List<int> myIntList = JsonConvert.DeserializeObject<List<int>>(myList);
            // Xử lý giá trị của myIntList
            return View();
        }
    }
}
