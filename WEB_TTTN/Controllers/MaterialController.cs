using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class MaterialController : Controller
    {
        private Getapi<Material> getapi;
        public MaterialController()
        {
            getapi = new Getapi<Material>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Material");
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
        public async Task<IActionResult> Create(Material obj)
        {
            try
            {
                getapi.CreateObj(obj, "Material");
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

            var lst = getapi.GetApi("Material");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Material obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Material");
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
            getapi.DeleteObj(id, "Material");
            return RedirectToAction("GetList");

        }
    }
}
