using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class ProductController : Controller
    {
       
        private Getapi<Product> getapi;
        public ProductController()
        {
            getapi = new Getapi<Product>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Product");
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
        public async Task<IActionResult> Create(Product obj)
        {
            try
            {
                getapi.CreateObj(obj, "Product");
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

            var lst = getapi.GetApi("Product");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Product obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Product");
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
            getapi.DeleteObj(id, "Product");
            return RedirectToAction("GetList");

        }
    }
}
