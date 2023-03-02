using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Travel_Website_Backend.Data;
using Travel_Website_Backend.Model;

namespace Travel_Website_Backend.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public readonly AppDbContext _context;
        public AdminRepository(AppDbContext context) {
            _context = context;
        }    
        public async Task <AdminModel> Login(string _Email,string _Password)
        {
            var records = await _context.Admins.Where(x => x.Email == _Email && x.Password == _Password).Select(x => new AdminModel()
            {

              Id= x.Id,
              Email=x.Email,
              Password=x.Password,



            }).FirstOrDefaultAsync();
            return records;
        }
    }
}
