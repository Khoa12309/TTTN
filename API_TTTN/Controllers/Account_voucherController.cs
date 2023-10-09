using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Account_voucherController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Account_voucher> _crud;
        public Account_voucherController()
        {
            _crud = new CRUDApi<Account_voucher>(_context, _context.Account_Vouchers);
        }
        [HttpGet]
        public IEnumerable<Account_voucher> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Account_voucher obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Account_voucher item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Account_voucher obj)
        {
            Account_voucher item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;          
            item.CreateDate = obj.CreateDate;
            item.Id_Voucher = obj.Id_Voucher;
                    
            return _crud.UpdateItem(item);
        }
    }
}
