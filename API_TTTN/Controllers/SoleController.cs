using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoleController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Sole> _crud;
        public SoleController()
        {
            _crud = new CRUDApi<Sole>(_context, _context.Soles);
        }
        [HttpGet]
        public IEnumerable<Sole> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Sole obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Sole item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Sole obj)
        {
            Sole item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Name = obj.Name;
            item.CreateDate = obj.CreateDate;
            item.Code = obj.Code;
            
            return _crud.UpdateItem(item);
        }
    }
}
