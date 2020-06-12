using System.Linq;
using Counter.Mongo;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Counter.Models
{
    public class CounterRepository : ICounterRepository
    {
        private readonly ICounterContext _context;

        public CounterRepository(ICounterContext context)
        {
            _context = context;
        }

        public async Task AddCounter(CounterInfo counterInfo)
        {
            await _context.CounterInfoCollection().InsertOneAsync(counterInfo);
        }

        public async Task<CounterInfo> GetCounter(string userId)
        {
            var filter = Builders<CounterInfo>.Filter.Where(a => a.UserId == userId);

            var cursor = await _context.CounterInfoCollection().FindAsync(filter);

            var records = await cursor.ToListAsync();

            if (records.Any())
            {
                return records.First();
            } else
            {
                return null;
            }
        }

        public async Task IncrementCounter(string userId)
        {
            var filter = Builders<CounterInfo>.Filter.Where(a => a.UserId == userId);

            var records = await _context.CounterInfoCollection().FindAsync(filter);

            var singleRecord = records.First();

            singleRecord.Counter++;

            await _context.CounterInfoCollection().ReplaceOneAsync(filter, singleRecord, new ReplaceOptions { IsUpsert = true });
        }

        public async Task DecrementCounter(string userId)
        {
            var filter = Builders<CounterInfo>.Filter.Where(a => a.UserId == userId);

            var records = await _context.CounterInfoCollection().FindAsync(filter);

            var singleRecord = records.First();

            singleRecord.Counter--;

            await _context.CounterInfoCollection().ReplaceOneAsync(filter, singleRecord, new ReplaceOptions { IsUpsert = true });
        }
    }
}