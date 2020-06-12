using Counter.Models;
using MongoDB.Driver;

namespace Counter.Mongo
{
    public interface ICounterContext
    {
        IMongoCollection<CounterInfo> CounterInfoCollection();
    }
}
