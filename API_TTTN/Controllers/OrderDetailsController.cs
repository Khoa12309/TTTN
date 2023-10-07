using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<OrderDetails> _crud;
        public OrderDetailsController()
        {
            _crud = new CRUDApi<OrderDetails>(_context, _context.OrderDetails);
        }
        [HttpGet]
        public IEnumerable<OrderDetails> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(OrderDetails obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            OrderDetails item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(OrderDetails obj)
        {
            OrderDetails item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
           item.Quantity=obj.Quantity;
            item.Status = obj.Status;
           item.Price=obj.Price;
            item.Id_productDetails=obj.Id_productDetails;

            return _crud.UpdateItem(obj);
        }
    }
}
