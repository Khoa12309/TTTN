using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class VoucherDetailsController : Controller
    {
        private Getapi<VoucherDetails> getapi;
        public VoucherDetailsController()
        {
            getapi = new Getapi<VoucherDetails>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("VoucherDetails");
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(VoucherDetails obj)
        {
            try
            {
                getapi.CreateObj(obj, "VoucherDetails");
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

            var lst = getapi.GetApi("VoucherDetails");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(VoucherDetails obj)
        {
            try
            {
                getapi.UpdateObj(obj, "VoucherDetails");
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            getapi.DeleteObj(id, "VoucherDetails");
            return RedirectToAction("GetList");

        }
    }
}
