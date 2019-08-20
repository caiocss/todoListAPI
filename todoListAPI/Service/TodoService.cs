using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListAPI.Models;

namespace todoListAPI.Service
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _todos;

        public TodoService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("todolistDb"));
            var database = client.GetDatabase("todolistDb");
            _todos = database.GetCollection<Todo>("todos");
        }

        public List<Todo> Get()
        {
            return _todos.Find(t => true).ToList();
        }

        public Todo Get(string id)
        {
            var todo = _todos.Find(t => t.Id == id).FirstOrDefault();
            return todo;
        }

        public Todo Create(Todo todo)
        {
            _todos.InsertOne(todo);
            return todo;
        }

        public void Update(Todo todo, string id)
        {
            _todos.ReplaceOne(t => t.Id == id, todo);
        }

        public void Remove(string id)
        {
            _todos.DeleteOne(t => t.Id == id);
        }


    }
}
