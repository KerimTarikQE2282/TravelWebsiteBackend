using System.Threading.Tasks;
using Travel_Website_Backend.Model;

namespace Travel_Website_Backend.Repository.EventRepository
{
    public interface IEventRepository
    {
        Task<int> AddEventsAsync(EventModel Event);
    }
}
