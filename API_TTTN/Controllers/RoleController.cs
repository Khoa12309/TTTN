using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Role> _crud;
        public RoleController()
        {
            _crud = new CRUDApi<Role>(_context, _context.Roles);
        }
        [HttpGet]
        public IEnumerable<Role> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Role obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Role item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Role obj)
        {
            Role item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Name=obj.Name;
            item.Code=obj.Code;            
            return _crud.UpdateItem(item);
        }
    }
}
