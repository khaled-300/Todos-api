using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.Model
{
    public class Todo
    {
        public Todo()
        {

        }
        public Todo(Guid Id, string Message)
        {
            this.Id = Id;
            this.Message = Message;
        }
        public Guid Id { get; set; }

        public string Message { get; set; }
    }
}
