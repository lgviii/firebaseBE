using Counter.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Counter.Mongo
{
    public class CounterContext : ICounterContext
    {
        private readonly IMongoDatabase _db;

        public CounterContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<CounterInfo> CounterInfoCollection() => _db.GetCollection<CounterInfo>("Counters");
    }
}
