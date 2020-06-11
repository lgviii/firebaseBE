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

        public async Task AddCounter(string userId)
        {
            var counterInfo = new CounterInfo();
            counterInfo.Counter = 0;
            counterInfo.UserId = userId;

            await _counterRepository.AddCounter(counterInfo);
        }

        public async Task<CounterInfo> GetCounter(string userId)
        {
            return await _counterRepository.GetCounter(userId);
        }

        public async Task IncrementCounter(string userId)
        {
            await _counterRepository.IncrementCounter(userId);
        }
        /*
       public async Task<ToDoItem[]> GetIncompleteItemsAsync()
       {
           //return await _context.Items.Where(a => a.IdDone == false).ToArrayAsync();
           var result = await _toDoRepo.ListToDoItems();
           return result.ToArray();
       }

       public async Task AddItem(ToDoItem toDoItem)
       {
           await _toDoRepo.AddToDoItems(toDoItem);
       }

       public async Task MarkDoneAsync(string id)
       {
           var item = await _toDoRepo.GetToDoItem(id);

           if (item == null) return;

           item.IdDone = !item.IdDone;

           await _toDoRepo.UpdateToDoItem(item);
       }*/
    }
}