using API_TTTN.Service;
using DataTTTN.ContextdataBase;
using DataTTTN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_TTTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        TTTNContext _context = new TTTNContext();
        private readonly CRUDApi<Image> _crud;
        public ImageController()
        {
            _crud = new CRUDApi<Image>(_context, _context.Images);
        }
        [HttpGet]
        public IEnumerable<Image> Getall()
        {
            return _crud.GetAllItems().ToList();
        }
        [Route("Post")]
        [HttpPost]
        public bool Create(Image obj)
        {
            return _crud.CreateItem(obj);
        }
        [Route("Delete")]
        [HttpDelete]
        public bool Delete(Guid id)
        {
            Image item = _crud.GetAllItems().FirstOrDefault(c => c.Id == id);
            return _crud.DeleteItem(item);
        }
        [Route("Update")]
        [HttpPut]
        public bool Update(Image obj)
        {
            Image item = _crud.GetAllItems().FirstOrDefault(c => c.Id == obj.Id);
            item.Last_modified_date = obj.Last_modified_date;
            item.Status = obj.Status;
            item.Name = obj.Name;
            item.Id_Product_details = obj.Id_Product_details;
            item.CreateDate = obj.CreateDate;


            return _crud.UpdateItem(obj);
        }
    }
}
