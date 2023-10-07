using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Color> _crud;
        public ColorController()
        {
            _crud = new CRUDApi<Color>(_context, _context.Colors);
        }
        [HttpGet]
        public IEnumerable<Color> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Color obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Color item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Color obj)
        {
            Color item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Name= obj.Name;
            item.Code = obj.Code;
            
            item.CreateDate = obj.CreateDate;
            

            return _crud.UpdateItem(obj);
        }
    }
}
