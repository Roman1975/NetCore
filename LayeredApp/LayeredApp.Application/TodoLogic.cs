using LayeredApp.Application.Interface;
using System;
using System.Collections.Generic;
using LayeredApp.Model;
using LayeredApp.Repository.Interface;
using System.Linq;
using LayeredApp.Domain;

namespace LayeredApp.Application
{
    public class TodoLogic : ITodoLogic
    {
        private IUnitOfWork _unitOfWork;

        public TodoLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<TodoModel> Get()
        {
            var todos = _unitOfWork.TodoRepository.GetAll().ToList();

            var models = new List<TodoModel>();
            foreach (TodoItem item in todos)
            {
                var model = new TodoModel()
                {
                    Id = item.Id,
                    Title = item.Title
                };

                models.Add(model);
            }

            return models;
        }

        public void Save(TodoModel model)
        {
            var item = new TodoItem() { Title = model.Title, IsCompleted = false, DateStart = DateTime.UtcNow };
            _unitOfWork.TodoRepository.Insert(item);
            _unitOfWork.Save();
        }
        
    }
}
