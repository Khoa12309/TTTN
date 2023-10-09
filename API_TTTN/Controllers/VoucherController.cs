using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Voucher> _crud;
        public VoucherController()
        {
            _crud = new CRUDApi<Voucher>(_context, _context.Vouchers);
        }
        [HttpGet]
        public IEnumerable<Voucher> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Voucher obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Voucher item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Voucher obj)
        {
            Voucher item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Name = obj.Name;
            item.CreateDate = obj.CreateDate;
            item.Code = obj.Code;
            item.Quantity = obj.Quantity;
            item.StartDate= obj.StartDate;
            item.EndDate= obj.EndDate;
            item.Value = obj.Value;
            return _crud.UpdateItem(item);
        }
    }
}
