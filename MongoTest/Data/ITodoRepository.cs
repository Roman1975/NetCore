using System.Collections.Generic;
using System.Threading.Tasks;
using MongoTest.Model;

namespace MongoTest.Data
{

    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAll();
        Task<Todo> Get(string id);

        // add new todo document
        Task Add(Todo item);
        
        // add a new comment for the todo
        Task AddComment(string id, Comment item);

        // remove a single document / todo
        Task<bool> Remove(string id);

        // update just a single document / todo
        Task<bool> Update(string id, Todo item);

        // set complete status on just a single document / todo
        Task<bool> Complete(string id);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> RemoveAll();
    }
}