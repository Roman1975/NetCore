using LayeredApp.Repository.Interface;
using LayeredApp.Domain;
using System;

namespace LayeredApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;

        private IGenericRepository<TodoItem> _todoRepo;

        public UnitOfWork(MyDbContext context)
        {
            _context = context;
            //_context.Configuration.LazyLoadingEnabled = false;  
        }

        public IGenericRepository<TodoItem> TodoRepository
        {
            get
            {
                if (_todoRepo == null)
                    _todoRepo = new GenericRepository<TodoItem>(_context);

                return _todoRepo;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

    }
}