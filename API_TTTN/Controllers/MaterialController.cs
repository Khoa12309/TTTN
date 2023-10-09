using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Material> _crud;
        public MaterialController()
        {
            _crud = new CRUDApi<Material>(_context, _context.Materials);
        }
        [HttpGet]
        public IEnumerable<Material> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Material obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Material item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Material obj)
        {
            Material item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Name = obj.Name;
          
            item.CreateDate = obj.CreateDate;


            return _crud.UpdateItem(item);
        }
    }
}
