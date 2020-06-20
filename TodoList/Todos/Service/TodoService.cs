using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Data;
using Todos.Model;

namespace Todos.Service
{
    public class TodoService : ITodoService
    {
        private readonly IRepository _repository;
        public TodoService(IRepository repository)
        {
            _repository = repository;
        }


        public Todo Create(Todo newTodo)
        {
            return _repository.Create(newTodo);
        }

        public void Delete(string id)
        {
            _repository.DeleteById(id);
        }

        public IList<Todo> GetAll()
        {
            return _repository.FindAll();
        }

        public Todo GetOne(string id)
        {
            return _repository.FindById(id);
        }

        public void Update(string id, Todo newTodo)
        {
            _repository.UpdateById(id, newTodo);
        }
    }
}
