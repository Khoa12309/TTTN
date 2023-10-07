using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<OrderHistory> _crud;
        public OrderHistoryController()
        {
            _crud = new CRUDApi<OrderHistory>(_context, _context.OrderHistories);
        }
        [HttpGet]
        public IEnumerable<OrderHistory> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(OrderHistory obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            OrderHistory item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(OrderHistory obj)
        {
            OrderHistory item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.ActionDescription=obj.ActionDescription;
            item.CreateDate=obj.CreateDate;
            item.Last_modified_date=obj.Last_modified_date;
            

            return _crud.UpdateItem(obj);
        }
    }
}
