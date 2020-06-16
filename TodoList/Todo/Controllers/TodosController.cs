using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {


        private static IList<Todos> TodoList = new List<Todos>
        {
            new Todos (Guid.NewGuid() ,"Freezing"),
            new Todos (Guid.NewGuid(), "Bracing"),
            new Todos (Guid.NewGuid() , "Chilly"),
            new Todos (Guid.NewGuid() ,"Cool"),
            new Todos (Guid.NewGuid() ,"Mild"),
            new Todos (Guid.NewGuid() ,"Warm"),
            new Todos (Guid.NewGuid() ,"Balmy"),
            new Todos (Guid.NewGuid() ,"Hot"),
            new Todos (Guid.NewGuid() ,"Sweltering"),
            new Todos (Guid.NewGuid() ,"Scorching")
        };
        // GET: api/<TodosController>
        [HttpGet]
        public IList<Todos> Get()
        {
            return TodoList;
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public Todos Get(Guid id)
        {
            var todo = TodoList.Where(x => x.Id.Equals(id)).FirstOrDefault();
            return todo;
        }

        // POST api/<TodosController>
        [HttpPost]
        public void Post([FromBody] Todos Todos)
        {
            Todos.Id = Guid.NewGuid();
            TodoList.Add(Todos);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Todos Todos)
        {
            Todos todo = TodoList.Where(x => x.Id == id).FirstOrDefault();
            TodoList.Remove(todo);
            Todos.Id = id;
            TodoList.Add(Todos);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var DeleteTodo = TodoList.Where(x => x.Id.Equals(id)).FirstOrDefault();
            TodoList.Remove(DeleteTodo);

        }
    }
}
