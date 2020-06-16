using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Todo.Model
{
    public class Todos
    {
        public Todos()
        {

        }
        public Todos(Guid Id, string Message)
        {
            this.Id = Id;
            this.Message = Message;
        }
        public Guid Id { get; set; }

        public string Message { get; set; }

    }
}
