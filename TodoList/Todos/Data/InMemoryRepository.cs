using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Model;

namespace Todos.Data
{
    public class InMemoryRepository : IRepository
    {

        private static IList<Todo> TodoList = new List<Todo>
        {
            new Todo (Guid.NewGuid() ,"Freezing"),
            new Todo (Guid.NewGuid() ,"Bracing"),
            new Todo (Guid.NewGuid() ,"Chilly"),
            new Todo (Guid.NewGuid() ,"Cool"),
            new Todo (Guid.NewGuid() ,"Mild"),
            new Todo (Guid.NewGuid() ,"Warm"),
            new Todo (Guid.NewGuid() ,"Balmy"),
            new Todo (Guid.NewGuid() ,"Hot"),
            new Todo (Guid.NewGuid() ,"Sweltering"),
            new Todo (Guid.NewGuid() ,"Scorching")
        };

        public Todo Create(Model.Todo todos)
        {
            todos.Id = Guid.NewGuid();
            TodoList.Add(todos);

            return todos;
        }

        public void DeleteById(string id)
        {
            var DeleteTodo = TodoList.Where(x => x.Id.Equals(id)).FirstOrDefault();
            TodoList.Remove(DeleteTodo);
        }

        public IList<Todo> FindAll()
        {
            return TodoList;
        }

        public Todo FindById(string id)
        {
            var todo = TodoList.Where(x => x.Id.Equals(id)).FirstOrDefault();
            return todo;
        }

        public void UpdateById(string id, Todo newTodo)
        {
            Todo oldTodo = TodoList.Where(x => x.Id.ToString().ToLower() ==  id.ToLower()).FirstOrDefault();
            newTodo.Id = oldTodo.Id;
            TodoList.Remove(oldTodo);
            TodoList.Add(newTodo);
        }
    }
}
