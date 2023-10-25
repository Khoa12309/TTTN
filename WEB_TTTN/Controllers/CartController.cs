using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
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
        private Getapi<Address> getapiAddress;
        private Getapi<Order> getapiOrder;
        private Getapi<OrderDetails> getapiOrderDetails;
        private Getapi<Voucher> getapiVoucher;

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
            getapiAddress=new Getapi<Address>();
            getapiOrder=new Getapi<Order>();
            getapiOrderDetails=new Getapi<OrderDetails>();
            getapiVoucher=new Getapi<Voucher>();
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
            ViewBag.User = SessionService.GetUserFromSession(HttpContext.Session, "User");
            ViewBag.pro = getapiProduct.GetApi("Product");
            ViewBag.Voucher = getapiVoucher.GetApi("Voucher");
          
            if (ViewBag.User.Id==Guid.Empty)
            {
                ViewBag.User = getapiUser.GetApi("User").FirstOrDefault(c => c.Id == ViewBag.User.Id);
               
               
            }
            ViewBag.Address = getapiAddress.GetApi("Address").FirstOrDefault(c => c.Id_User == ViewBag.User.Id);

            return View(lst);
        } 
        public IActionResult thanhtoan(string tp, string phuong, string quan, string phone, string name,string address,Guid id)
        {
            var lst = SessionService.GetObjFromSession(HttpContext.Session, "Cart");
            var user=    SessionService.GetUserFromSession(HttpContext.Session, "User");
          
           float total = 0;
            foreach (var item in lst)
            {
                total += item.Quantity * item.Price; 
            }
            if (user==null)
            {
                user.Id = Guid.Empty;

            }
            if (user != null&& user.Id==id)
            {
               
                    var add= getapiAddress.GetApi("Address").FirstOrDefault(c => c.Id_User == user.Id);
                var idhd = Guid.NewGuid();
               
                var order = new Order()
                {
                    Id = idhd,
                    Name = name,
                    Address = address+","+phuong + "," + quan + "," + tp,
                    CreateDate = DateTime.Now,
                    PhoneNumber = phone,
                    Status = 1,
                    Transportfee = 0,
                    Id_User = user.Id,
                    TotalMoney =total,
                    Last_modified_date = DateTime.Now,
                     Note= tp,
                };

                getapiOrder.CreateObj(order, "Order");

                foreach (var item in lst)
                {
                    var orderdetails = new OrderDetails()
                    {
                        Id_order = idhd,
                        Id_productDetails=item.Id,
                        Quantity = item.Quantity,
                           Price = item.Price,
                    };
               
                   var a= getapiOrderDetails.CreateObj(orderdetails, "OrderDetails");

                    var pro = getapi.GetApi("Product_details").FirstOrDefault(c => c.Id == item.Id);
                    pro.Quantity =pro.Quantity- item.Quantity;
                    getapi.UpdateObj(pro, "Product_details");
                   
                }

               
                SessionService.GetObjFromSession(HttpContext.Session, "Cart").Clear();
                lst.Clear();
                SessionService.SetObjToJson(HttpContext.Session, "Cart", lst);

            }
            return View();
        }


    }
}
