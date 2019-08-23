using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoListAPI.Models;

namespace todoListAPI.Service
{
    public class AuthService
    {
        private readonly IMongoCollection<User> _user;
        public AuthService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("todolistDb"));
            var database = client.GetDatabase("todolistDb");
            _user = database.GetCollection<User>("users");
        }

        public User Get(string id)
        {
            var user = _user.Find(t => t.Id == id).FirstOrDefault();
            return user;
        }

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(User user, string id)
        {
            _user.ReplaceOne(t => t.Id == id, user);
        }

        public void Remove(string id)
        {
            _user.DeleteOne(t => t.Id == id);
        }

    }
}
