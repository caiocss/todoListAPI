using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using todoListAPI.Models;
using todoListAPI.Service;

namespace todoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodosController(TodoService todoService)
        {
            _todoService = todoService;
        }

        // GET api/todos
        [Authorize("Bearer")]
        [HttpGet]
        public ActionResult<List<Todo>> Get()
        {
            return _todoService.Get();
        }

        [Authorize("Bearer")]
        [HttpGet("{username}")]
        public ActionResult<List<Todo>> Get(string username)
        {
            return _todoService.Get(username);
        }

        // POST api/todos
        [Authorize("Bearer")]
        [HttpPost]
        public ActionResult<Todo> Post(Todo todo)
        {
            return _todoService.Create(todo);
        }

        // PUT api/todos/{informar id}
        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public IActionResult Put(string id, Todo todo)
        {
            var t = _todoService.Get(id);

            if (t == null)
            {
                return NotFound();
            }

            _todoService.Update(todo, id);
            return NoContent();
        }

        // PUT api/todos/{informar id}
        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _todoService.Remove(id);
        }
    }
}
