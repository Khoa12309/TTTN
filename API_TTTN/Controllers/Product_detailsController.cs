using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_detailsController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Product_details> _crud;
        public Product_detailsController()
        {
            _crud = new CRUDApi<Product_details>(_context, _context.Products_details);
        }
        [HttpGet]
        public IEnumerable<Product_details> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Product_details obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Product_details item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Product_details obj)
        {
            Product_details item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            
            item.Last_modified_date = obj.Last_modified_date;
            item.CreateDate = obj.CreateDate;
            item.Status = obj.Status;
            item.Description = obj.Description;
            item.Price = obj.Price;
            item.Id_Product = obj.Id_Product;
            item.Id_Material = obj.Id_Material;
            item.Id_Brand = obj.Id_Brand;
            item.Id_Size = obj.Id_Size;
            item.Id_Color = obj.Id_Color;
            item.Id_Sole=obj.Id_Sole;
            item.Id_Category = obj.Id_Category;
            item.Quantity = obj.Quantity;
            

            return _crud.UpdateItem(item);
        }
    }
}
