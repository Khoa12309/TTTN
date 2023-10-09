using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Notification> _crud;
        public NotificationController()
        {
            _crud = new CRUDApi<Notification>(_context, _context.Notifications);
        }
        [HttpGet]
        public IEnumerable<Notification> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Notification obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Notification item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Notification obj)
        {
            Notification item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Noti_conten=obj.Noti_conten;           
            item.CreateDate = obj.CreateDate;


            return _crud.UpdateItem(item);
        }
    }
}
