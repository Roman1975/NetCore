using LayeredApp.Model;
using System.Collections.Generic;

namespace LayeredApp.Application.Interface
{
    public interface ITodoLogic
    {
        List<TodoModel> Get();
        void Save(TodoModel model);
       
    }
}
