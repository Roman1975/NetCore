using System.Linq;
using LayeredApp.Repository.Interface;
using LayeredApp.Domain;

namespace LayeredApp.Repository
{  
    public class GenericRepository<T> : IGenericRepository<T> where T : class  
    {  
        protected MyDbContext _context;  
  
        public GenericRepository(MyDbContext context)  
        {  
            _context = context;  
        }  
  
        public IQueryable<T> GetAll()  
        {  
            IQueryable<T> query = _context.Set<T>();  
            return query;  
        }  
  
        public void Insert(T entity)  
        {  
            _context.Set<T>().Add(entity);  
        }  
  
        public void Update(T entity)  
        {  
            _context.Set<T>().Attach(entity);  
        }  
  
        public void Delete(T entity)  
        {  
            _context.Set<T>().Remove(entity);  
        }  
    }  
}  