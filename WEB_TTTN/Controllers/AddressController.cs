using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
	public class AddressController : Controller
	{
        private Getapi<Address> getapi;
        public AddressController()
        {
            getapi = new Getapi<Address>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Address");
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(Address obj)
        {
            try
            {
                getapi.CreateObj(obj, "Address");
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

            var lst = getapi.GetApi("Address");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Address obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Address");
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
            getapi.DeleteObj(id, "Address");
            return RedirectToAction("GetList");

        }
    }
}
