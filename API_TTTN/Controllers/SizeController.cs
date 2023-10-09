using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Size> _crud;
        public SizeController()
        {
            _crud = new CRUDApi<Size>(_context,_context.Sizes);
        }
        [HttpGet]
        public IEnumerable<Size> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Size obj)
        {                     
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Size item= _crud.GetAllItems().FirstOrDefault(c=>c.Id==id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Size obj)
        {
            Size item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Name = obj.Name;
            return _crud.UpdateItem(item); 
        }
    }
}
