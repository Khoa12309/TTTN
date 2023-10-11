using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class BrandController : Controller
    {
        private Getapi<Brand> getapi;
        public BrandController()
        {
            getapi = new Getapi<Brand>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Brand");
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(Brand obj)
        {
            try
            {
                getapi.CreateObj(obj, "Brand");
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]

        // GET: SupplierController1/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {

            var lst = getapi.GetApi("Brand");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Brand obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Brand");
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
            getapi.DeleteObj(id, "Brand");
            return RedirectToAction("GetList");

        }
    }
}
