
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoApi.Models
{
    public class Message
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Ms { get; set; }
        public DateTime Date { get; set; }
    }
}
