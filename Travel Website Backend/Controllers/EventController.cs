using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Travel_Website_Backend.Model;
using Travel_Website_Backend.Repository;
using Travel_Website_Backend.Repository.EventRepository;

namespace Travel_Website_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public readonly IEventRepository AdminRepository;
        public EventController(IEventRepository Ar)
        {
            AdminRepository = Ar;
        }
        [HttpPost("")]
       
        public async Task<IActionResult> AddEvent([FromBody] EventModel Event)
        {
            var EventId = await AdminRepository.AddEventsAsync(Event);
            return Ok(EventId) /*CreatedAtAction(nameof(GetHospitalById),new { HospitalId= HospitalId ,controller="Hospitals"}, HospitalId)*/;
        }
    }
}
