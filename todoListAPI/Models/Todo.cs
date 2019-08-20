using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [BsonElement("Name")]
        public string Name { get; set; }

        [Required]
        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [Required]
        [BsonElement("UserId")]
        public string UserId { get; set; }

        [Required]
        [BsonElement("Done")]
        public bool Done { get; set; }
    }
}
