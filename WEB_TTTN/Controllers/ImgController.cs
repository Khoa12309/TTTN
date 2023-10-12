using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using WEB_TTTN.Service;

namespace WEB_TTTN.Controllers
{
    public class ImgController : Controller
    {
        private Getapi<Image> getapi;
        private Getapi<Product> getapipro;
        private Getapi<Product_details> getapipd;
        public ImgController()
        {
            getapi = new Getapi<Image>();
            getapipro = new Getapi<Product>();
            getapipd = new Getapi<Product_details>();
        }

        public async Task<IActionResult> GetList()
        {
            var obj = getapi.GetApi("Image");
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
            ViewBag.product=getapipro.GetApi("Product");
            return View();
        }

        // POST: SupplierController1/Create
        [HttpPost]
        public async Task<IActionResult> Create(Image obj, [Bind] IFormFile imageFile)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0) // Không null và không trống
                {
                    //Trỏ tới thư mục wwwroot để lát nữa thực hiện việc Copy sang
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        // Thực hiện copy ảnh vừa chọn sang thư mục mới (wwwroot)
                        imageFile.CopyTo(stream);
                    }
                    // Gán lại giá trị cho Description của đối tượng bằng tên file ảnh đã được sao chép
                    var pd= getapipd.GetApi("Product_details").FirstOrDefault(c=>c.Id_Product==obj.Id_Product_details);
                    obj.Id_Product_details = pd.Id;
                    obj.Name = imageFile.FileName;


                }

                getapi.CreateObj(obj, "Image");
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

            var lst = getapi.GetApi("Image");
            return View(lst.Find(c => c.Id == id));
        }

        //// POST: SupplierController1/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Image obj)
        {
            try
            {
                getapi.UpdateObj(obj, "Image");
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
            getapi.DeleteObj(id, "Image");
            return RedirectToAction("GetList");

        }
    }
}
