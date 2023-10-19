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
        private Getapi<User> getapiUser;
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
            getapiUser=new Getapi<User>();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cart()
        {
            var lst = SessionService.GetObjFromSession(HttpContext.Session, "Cart"); 
            ViewBag.Product = getapiProduct.GetApi("Product");         
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

            SessionService.GetObjFromSession(HttpContext.Session, "Cart").Clear();          
            SessionService.SetObjToJson(HttpContext.Session, "Cart", item);
            return RedirectToAction( "checkout");
        }


        public async Task<IActionResult> AddToCart(Guid id, int soluong)
        {
            var product = getapi.GetApi("Product_details").Find(c => c.Id == id);
            product.Quantity = soluong;
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
                    productcart.Quantity += soluong;
                    products.Remove(productcart);
                    products.Add(productcart);
                    SessionService.SetObjToJson(HttpContext.Session, "Cart", products);

                }
            }
            return RedirectToAction("Cart");
        }
        public IActionResult DeleteCartItem(Guid id)
        {
            var products = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            var p = products.Find(c => c.Id == id);
            products.Remove(p);
            SessionService.SetObjToJson(HttpContext.Session, "Cart", products);

            return RedirectToAction("Cart");
        }
        public IActionResult checkout()
        {
            var lst = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            ViewBag.User = getapiUser.GetApi("User");
            return View(lst);

        }
    }
}
