using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<PaymentMethod> _crud;
        public PaymentMethodController()
        {
            _crud = new CRUDApi<PaymentMethod>(_context, _context.PaymentMethods);
        }
        [HttpGet]
        public IEnumerable<PaymentMethod> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(PaymentMethod obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            PaymentMethod item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(PaymentMethod obj)
        {
            PaymentMethod item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Description = obj.Description;
            item.TotalMoney = obj.TotalMoney;
            item.CreateDate = obj.CreateDate;           
            return _crud.UpdateItem(obj);
        }
    }
}
