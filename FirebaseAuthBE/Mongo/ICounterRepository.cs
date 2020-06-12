using System.Threading.Tasks;

namespace Counter.Models
{
    public interface ICounterRepository
    {
        Task AddCounter(CounterInfo counterInfo);
        Task<CounterInfo> GetCounter(string userId);
        Task IncrementCounter(string userId);
        Task DecrementCounter(string userId);
    }
}