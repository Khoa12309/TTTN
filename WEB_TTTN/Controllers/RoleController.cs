using DataTTTN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private Getapi<Role> getapi;
        public RoleController()
        {
            getapi = new Getapi<Role>();
        }
        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Role");
            return View(obj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(Role obj)
        {
            try
            {
                obj.Id = Guid.NewGuid();
               var r= getapi.CreateObj(obj, "Role");
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
           var r= getapi.DeleteObj(id, "Role");
            return RedirectToAction("GetList");

        }
        [HttpGet]

     
        public async Task<IActionResult> Edit(Guid id)
        {

            var lst = getapi.GetApi("Role");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Role obj)
        {
            try
            {
                var r = getapi.UpdateObj(obj, "Role");
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }

    }
}
