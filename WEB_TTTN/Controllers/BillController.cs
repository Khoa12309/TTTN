using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
	public class OrderController : Controller
	{
        private Getapi<Order> getapi;
        public OrderController()
        {
            getapi = new Getapi<Order>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Order");
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(Order obj)
        {
            try
            {
                getapi.CreateObj(obj, "Order");
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

            var lst = getapi.GetApi("Order");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Order obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Order");
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
            getapi.DeleteObj(id, "Order");
            return RedirectToAction("GetList");

        }
    }
}
