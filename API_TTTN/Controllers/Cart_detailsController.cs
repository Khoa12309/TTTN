using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cart_detailsController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Cart_details> _crud;
        public Cart_detailsController()
        {
            _crud = new CRUDApi<Cart_details>(_context, _context.Cart_Details);
        }
        [HttpGet]
        public IEnumerable<Cart_details> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Cart_details obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Cart_details item = _crud.GetAllItems().FirstOrDefault(c => c.ID == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Cart_details obj)
        {
            Cart_details item = _crud.GetAllItems().FirstOrDefault(c => c.ID == obj.ID);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Id_productdetails = obj.Id_productdetails;
            item.CreateDate = obj.CreateDate;
            item.Price = obj.Price;
            item.Quantity = obj.Quantity;
            return _crud.UpdateItem(obj);
        }
    }
}
