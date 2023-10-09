using DataTTTN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    
    [Authorize(Roles ="Admin")]
    public class SizeController : Controller
    {
        private Getapi<Size> getapi;
        public SizeController()
        {
            getapi = new Getapi<Size>();
        }
      
        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Size");
            return View(obj);
        }

        // GET: SupplierController1/Details/5
        //public async Task<IActionResult> Details(Guid id)
        //{
        //    return View();
        //}

        //// GET: SupplierController1/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(Size obj)
        {
            try
            {
                getapi.CreateObj(obj, "Size");
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

            var lst = getapi.GetApi("Size");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Size obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Size");
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
            getapi.DeleteObj(id, "Size");
            return RedirectToAction("GetList");

        }
    }
}
