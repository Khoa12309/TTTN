using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Product> _crud;
        public ProductController()
        {
            _crud = new CRUDApi<Product>(_context, _context.Products);
        }
        [HttpGet]
        public IEnumerable<Product> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Product obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Product item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Product obj)
        {
            Product item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Name = obj.Name;
            item.Code = obj.Code;
            item.Last_modified_date = obj.Last_modified_date;
            item.CreateDate = obj.CreateDate;
            item.Status = obj.Status;
            
            return _crud.UpdateItem(item);
        }
    }
}
