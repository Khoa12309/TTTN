using DataTTTN.ContextdataBase;
using Microsoft.EntityFrameworkCore;

namespace API_TTTN.Service
{
    public class CRUDApi<T> where T : class
    {
        TTTNContext _context;
        DbSet<T> _dbSet;
        public CRUDApi()
        {

        }
        public CRUDApi( TTTNContext context ,DbSet<T> dbset)
        {
            _context = context;
            _dbSet = dbset;
        }
        public bool CreateItem(T item)
        {
            try
            {
                _dbSet.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeleteItem(T item)
        {
            try
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<T> GetAllItems()
        {
            return _dbSet.ToList();
        }

        public bool UpdateItem(T item)
        {
            try
            {
                _dbSet.Update(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
