using LayeredApp.Domain;

namespace LayeredApp.Repository.Interface
{
    public interface IUnitOfWork   
    {  
        IGenericRepository<TodoItem> TodoRepository { get; }
  
        int Save();  
    }  
}