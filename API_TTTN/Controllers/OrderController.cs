using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Order> _crud;
        public OrderController()
        {
            _crud = new CRUDApi<Order>(_context, _context.Orders);
        }
        [HttpGet]
        public IEnumerable<Order> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Order obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Order item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Order obj)
        {
            Order item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Name = obj.Name;
            item.Address = obj.Address;
            item.CreateDate = obj.CreateDate;
            item.TotalMoney = obj.TotalMoney;
            item.Note = obj.Note;
            item.PhoneNumber = obj.PhoneNumber;
            item.Transportfee = obj.Transportfee;
            return _crud.UpdateItem(item);
        }
    }
}
