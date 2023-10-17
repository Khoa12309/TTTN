using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class CartController : Controller
    {

        private Getapi<Product_details> getapi;
        private Getapi<Size> getapiSize;
        private Getapi<Color> getapiColor;
        private Getapi<Category> getapiCategory;
        private Getapi<Material> getapiMaterial;
        private Getapi<Sole> getapiSole;
        private Getapi<Brand> getapiBrand;
        private Getapi<Product> getapiProduct;
        private Getapi<Image> getapiImg;
        public CartController()
        {
            getapi = new Getapi<Product_details>();
            getapiSize = new Getapi<Size>();
            getapiColor = new Getapi<Color>();
            getapiCategory = new Getapi<Category>();
            getapiMaterial = new Getapi<Material>();
            getapiSole = new Getapi<Sole>();
            getapiBrand = new Getapi<Brand>();
            getapiProduct = new Getapi<Product>();
            getapiImg = new Getapi<Image>();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cart()
        {
            var lst = getapi.GetApi("Product_details");
            ViewBag.Product = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            var a = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            ViewBag.Size = getapiSize.GetApi("Size");
            ViewBag.Color = getapiColor.GetApi("Color");
            ViewBag.Sole = getapiSole.GetApi("Sole");
            ViewBag.Category = getapiCategory.GetApi("Category");
            ViewBag.Material = getapiMaterial.GetApi("Material");
            ViewBag.Brand = getapiBrand.GetApi("Brand");
            ViewBag.Img = getapiImg.GetApi("Image");
            return View(lst);
        }
        [HttpPost]
        public IActionResult Cart(List<DataTTTN.Models.Product_details> item)
        {
            var a = new List<DataTTTN.Models.Product_details>();
            a = item.ToList();

            return RedirectToAction("productdeatils/getlist");
        }


        public async Task<IActionResult> AddToCart(Guid id, int SoLuong)
        {
            var product = getapiProduct.GetApi("Product").Find(c => c.Id == id);
            product.Quantity = SoLuong;
            var products = SessionService.GetObjFromSession(HttpContext.Session, "Cart");

            if (products.Count == 0)
            {

                products.Add(product);
                SessionService.SetObjToJson(HttpContext.Session, "Cart", products);

            }
            else
            {
                if (!SessionService.CheckProductInCart(id, products)) // SP chưa nằm trong cart
                {
                    products.Add(product);

                    SessionService.SetObjToJson(HttpContext.Session, "Cart", products);
                }
                else
                {
                    var productcart = products.FirstOrDefault(c => c.Id == id);
                    productcart.Quantity += SoLuong;
                    products.Remove(productcart);
                    products.Add(productcart);
                    SessionService.SetObjToJson(HttpContext.Session, "Cart", products);

                }
            }
            return RedirectToAction("Cart");
        }

        public void listcheckout(IEnumerable<DataTTTN.Models.Product_details> item)
        {

        }
    }
}
