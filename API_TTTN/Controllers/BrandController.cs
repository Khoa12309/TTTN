using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Brand> _crud;
        public BrandController()
        {
            _crud = new CRUDApi<Brand>(_context, _context.Brands);
        }
        [HttpGet]
        public IEnumerable<Brand> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Brand obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Brand item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Brand obj)
        {
            Brand item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
           item.Name = obj.Name;
            
            item.CreateDate = obj.CreateDate;
           

            return _crud.UpdateItem(item);
        }
    }
}
