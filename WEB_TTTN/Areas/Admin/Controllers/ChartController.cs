using DataTTTN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Areas.Admin.Controllers
{
    [Area("Admin")]
    // [Authorize(Roles = "Admin")]
    public class ChartController : Controller
	{
      
        
        private Getapi<Product_details> getapi;
        private Getapi<OrderDetails> getapiHDCT;
        private Getapi<Product> getapiProduct;
		public ChartController()
		{
			getapi = new Getapi<Product_details>();
			getapiHDCT = new Getapi<OrderDetails>();
            getapiProduct = new Getapi<Product>();
           
        }
        public IActionResult Chart()
		{
            ViewBag.HDCT = getapiHDCT.GetApi("OrderDetails");
            ViewBag.Product = getapiProduct.GetApi("Product");
            var obj = getapi.GetApi("Product_details");
            return View(obj);
        }
	}
}
