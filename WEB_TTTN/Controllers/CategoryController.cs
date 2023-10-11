using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class CategoryController : Controller
    {
        private Getapi<Category> getapi;
        public CategoryController()
        {
            getapi = new Getapi<Category>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Category");
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
        public async Task<IActionResult> Create(Category obj)
        {
            try
            {
                getapi.CreateObj(obj, "Category");
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

            var lst = getapi.GetApi("Category");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Category obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Category");
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
            getapi.DeleteObj(id, "Category");
            return RedirectToAction("GetList");

        }
    }
}
