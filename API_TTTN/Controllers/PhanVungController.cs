using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhanVungController : ControllerBase
    {

        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Phanvung> _crud;
        public PhanVungController()
        {
            _crud = new CRUDApi<Phanvung>(_context, _context.Phanvungs);
        }
        [HttpGet]
        public IEnumerable<Phanvung> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Phanvung obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Phanvung item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Phanvung obj)
        {
            Phanvung item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Note=obj.Note;
            item.Id_User=obj.Id_User;
            item.Id_Role=obj.Id_Role;

            return _crud.UpdateItem(item);
        }
    }
}
