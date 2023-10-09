using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherDetailsController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<VoucherDetails> _crud;
        public VoucherDetailsController()
        {
            _crud = new CRUDApi<VoucherDetails>(_context, _context.VoucherDetails);
        }
        [HttpGet]
        public IEnumerable<VoucherDetails> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(VoucherDetails obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            VoucherDetails item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(VoucherDetails obj)
        {
            VoucherDetails item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.AfterPrice=obj.AfterPrice;
            item.BeforPrice=obj.BeforPrice;
            item.DiscountPrice=obj.DiscountPrice;
            item.Id_Voucher=obj.Id_Voucher;
            item.Id_order=obj.Id_order;
            item.Id_Voucher = obj.Id_Voucher;            
            return _crud.UpdateItem(obj);
        }
    }
}
