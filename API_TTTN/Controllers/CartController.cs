using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Cart> _crud;
        public CartController()
        {
            _crud = new CRUDApi<Cart>(_context, _context.Carts);
        }
        [HttpGet]
        public IEnumerable<Cart> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Cart obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Cart item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Cart obj)
        {
            Cart item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Create_at=obj.Create_at;
           

            return _crud.UpdateItem(obj);
        }
    }
}
