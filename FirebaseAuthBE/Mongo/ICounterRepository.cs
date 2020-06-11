using System.Threading.Tasks;

namespace Counter.Models
{
    public interface ICounterRepository
    {
        Task IncrementCounter(string userId);
        Task AddCounter(CounterInfo counterInfo);
        Task<CounterInfo> GetCounter(string userId);
    }
}