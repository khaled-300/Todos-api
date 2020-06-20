using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Model;

namespace Todos.Service
{
    public interface ITodoService
    {
        IList<Todo> GetAll();

        Todo GetOne(string id);

        void Update(string id, Todo newTodo);

        void Delete(string id);

        Todo Create(Todo newTodo);
    }
}
