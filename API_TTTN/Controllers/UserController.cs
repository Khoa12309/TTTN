using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<User> _crud;
        public UserController()
        {
            _crud = new CRUDApi<User>(_context, _context.Users);
        }
        [HttpGet]
        public IEnumerable<User> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(User obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            User item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(User obj)
        {
            User item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.PhoneNumber = obj.PhoneNumber;
            item.Point = obj.Point;
            item.Gender = obj.Gender;
            item.Dateofbirth=obj.Dateofbirth;
            item.Fullname = obj.Fullname;
            item.Status = obj.Status;
            item.Email = obj.Email;                     
            return _crud.UpdateItem(obj);
        }
    }
}
