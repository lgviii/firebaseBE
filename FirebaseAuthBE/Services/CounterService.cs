using System.Threading.Tasks;
using Counter.Models;

namespace Counter.Services
{
    public class CounterService : ICounterService
    {

        private readonly ICounterRepository _counterRepository;

        public CounterService(ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;
        }

        public async Task<CounterInfo> AddCounter(string userId)
        {
            var counterInfo = new CounterInfo
            {
                Counter = 0,
                UserId = userId
            };

            await _counterRepository.AddCounter(counterInfo);

            return await _counterRepository.GetCounter(userId);
        }

        public async Task<CounterInfo> GetCounter(string userId)
        {
            return await _counterRepository.GetCounter(userId);
        }

        public async Task IncrementCounter(string userId)
        {
            await _counterRepository.IncrementCounter(userId);
        }

        public async Task DecrementCounter(string userId)
        {
            await _counterRepository.DecrementCounter(userId);
        }
    }
}