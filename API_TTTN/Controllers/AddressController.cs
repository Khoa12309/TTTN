using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Address> _crud;
        public AddressController()
        {
            _crud = new CRUDApi<Address>(_context, _context.Addresses);
        }
        [HttpGet]
        public IEnumerable<Address> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Address obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Address item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Address obj)
        {
            Address item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Wards=obj.Wards;
             item.Id_User=obj.Id_User;
             item.District=obj.District;
             item.City=obj.City;
            item.Detailed_address=obj.Detailed_address;
          

            return _crud.UpdateItem(obj);
        }
    }
}
