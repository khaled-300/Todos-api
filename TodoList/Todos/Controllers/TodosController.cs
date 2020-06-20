using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todos.Model;
using Todos.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {

        private readonly ITodoService _todoService;

        public TodosController(ITodoService TodoService)
        {
            _todoService = TodoService;
        }


        // GET: api/<TodosController>
        [HttpGet]
        public IList<Todo> Get()
        {
           return _todoService.GetAll();
        }

        // GET api/<TodosController>/5
        [HttpGet("{id}")]
        public Todo Get(string id)
        {
            return _todoService.GetOne(id);
        }

        // POST api/<TodosController>
        [HttpPost]
        public void Post([FromBody] Todo todo)
        {
            _todoService.Create(todo);
        }

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Todo Todos)
        {
            _todoService.Update(id, Todos);
        }

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _todoService.Delete(id);

        }
    }
}
