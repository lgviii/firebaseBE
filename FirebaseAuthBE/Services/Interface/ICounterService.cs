using Counter.Models;
using System.Threading.Tasks;

namespace Counter.Services
{
    public interface ICounterService
    {
        Task IncrementCounter(string userId);
        Task AddCounter(string userId);
        Task<CounterInfo> GetCounter(string userId);
    }
}
