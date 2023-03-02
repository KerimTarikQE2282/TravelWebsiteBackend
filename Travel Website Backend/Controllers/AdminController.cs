using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Travel_Website_Backend.Model;
using Travel_Website_Backend.Repository;

namespace Travel_Website_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly IAdminRepository AdminRepository;
        public AdminController(IAdminRepository Ar) {
            AdminRepository = Ar;
        }
        [HttpGet("")]
        public async Task<IActionResult> AdminLogin([FromBody] Login login )
        {
            var Status = await AdminRepository.Login(login.Email, login.Password);
            return Ok(Status);
        }
    }
}
