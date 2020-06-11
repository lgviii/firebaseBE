
using MongoDB.Bson.Serialization.Attributes;

namespace Counter.Models
{
    public class CounterInfo
    {
        [BsonId]
        public string Id { get; set; }

        public string UserId { get; set; }
        public int Counter { get; set; }
    }
}