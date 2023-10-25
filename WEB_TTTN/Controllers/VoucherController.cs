using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class VoucherController : Controller
    {
        private Getapi<Voucher> getapi;
        public VoucherController()
        {
            getapi = new Getapi<Voucher>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Voucher");
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(Voucher obj)
        {
            try
            {
                getapi.CreateObj(obj, "Voucher");
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

            var lst = getapi.GetApi("Voucher");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Voucher obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Voucher");
                return RedirectToAction("GetList");
            }
            catch
            {
                return View();
            }
        }

        
        public async Task<IActionResult> Delete(Guid id)
        {
            getapi.DeleteObj(id, "Voucher");
            return RedirectToAction("GetList");

        }
    }
}
