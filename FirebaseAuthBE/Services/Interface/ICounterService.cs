using Counter.Models;
using System.Threading.Tasks;

namespace Counter.Services
{
    public interface ICounterService
    {
        Task<CounterInfo> AddCounter(string userId);
        Task<CounterInfo> GetCounter(string userId);
        Task IncrementCounter(string userId);
        Task DecrementCounter(string userId);
    }
}
