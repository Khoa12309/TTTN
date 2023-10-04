using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Account> _crud;
        public AccountController()
        {
            _crud = new CRUDApi<Account>(_context, _context.Accounts);
        }
        [HttpGet]
        public IEnumerable<Account> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Account obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Account item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Account obj)
        {
            Account item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Email = obj.Email;
            item.CreateDate = obj.CreateDate;
            item.Password = obj.Password;
            
            return _crud.UpdateItem(obj);
        }
    }
}
