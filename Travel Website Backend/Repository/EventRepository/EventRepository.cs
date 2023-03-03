using System.Threading.Tasks;
using Travel_Website_Backend.Data;
using Travel_Website_Backend.Model;

namespace Travel_Website_Backend.Repository.EventRepository
{
    public class EventRepository:IEventRepository
    {
        public readonly AppDbContext _context;
        public EventRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddEventsAsync(EventModel Event)
        {


            var NewEvent = new Event()
            {

                EventName = Event.EventName,
                EventDescription = Event.EventDescription,
                EventImage = Event.EventImage,
             

            };
            _context.Events.Add(NewEvent);
            await _context.SaveChangesAsync();
            return NewEvent.EventId;







        }
    }
}
