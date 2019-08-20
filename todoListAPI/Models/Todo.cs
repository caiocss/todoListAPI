using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace todoListAPI.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("Done")]
        public bool Done { get; set; }
    }
}
