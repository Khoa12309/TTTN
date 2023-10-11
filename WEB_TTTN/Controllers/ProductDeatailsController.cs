using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class ProductDetailsController : Controller
    {
        private Getapi<Product_details> getapi; 
        private Getapi<Size> getapiSize;
        private Getapi<Color> getapiColor;
        private Getapi<Category> getapiCategory;
        private Getapi<Material> getapiMaterial;
        private Getapi<Sole> getapiSole;
        private Getapi<Brand> getapiBrand;
        private Getapi<Product> getapiProduct;

        public ProductDetailsController()
        {
            getapi = new Getapi<Product_details>();
            getapiSize = new Getapi<Size>();
            getapiColor = new Getapi<Color>();
            getapiCategory = new Getapi<Category>();
            getapiMaterial = new Getapi<Material>();
            getapiSole = new Getapi<Sole>();
            getapiBrand = new Getapi<Brand>();
            getapiProduct = new Getapi<Product>();
        }

        public async Task<IActionResult> GetList()
        {
           
            var obj = getapi.GetApi("Product_details");
            return View(obj);
        }

        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Size = getapiSize.GetApi("Size");
            ViewBag.Color = getapiColor.GetApi("Color");
            ViewBag.Sole = getapiSole.GetApi("Sole");
            ViewBag.Category = getapiCategory.GetApi("Category");
            ViewBag.Material = getapiMaterial.GetApi("Material");
            ViewBag.Brand = getapiBrand.GetApi("Brand");
            ViewBag.Product = getapiProduct.GetApi("Product");
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(Product_details obj)
        {
            try
            {
                getapi.CreateObj(obj, "Product_details");
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
            ViewBag.Size = getapiSize.GetApi("Size");
            ViewBag.Color = getapiColor.GetApi("Color");
            ViewBag.Sole = getapiSole.GetApi("Sole");
            ViewBag.Category = getapiCategory.GetApi("Category");
            ViewBag.Material = getapiMaterial.GetApi("Material");
            ViewBag.Brand = getapiBrand.GetApi("Brand");
            ViewBag.Product = getapiProduct.GetApi("Product");
            var lst = getapi.GetApi("Product_details");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Product_details obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Product_details");
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
            getapi.DeleteObj(id, "Product_details");
            return RedirectToAction("GetList");

        }
    }
}
