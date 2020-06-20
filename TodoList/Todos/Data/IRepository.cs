using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Model;

namespace Todos.Data
{
    public interface IRepository
    {

        IList<Todo> FindAll();

        Todo FindById(string id);

        void UpdateById(string id, Model.Todo newTodo);

        void DeleteById(string id);

        Todo Create(Model.Todo todos);

    }
}
