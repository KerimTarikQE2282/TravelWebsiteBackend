using Microsoft.AspNetCore.Http;

namespace Travel_Website_Backend.Data
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public byte EventImage { get; set; }
    }
}
