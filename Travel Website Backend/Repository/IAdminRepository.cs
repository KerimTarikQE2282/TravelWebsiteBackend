using System.Threading.Tasks;
using Travel_Website_Backend.Model;

namespace Travel_Website_Backend.Repository
{
    public interface IAdminRepository
    {
        Task<AdminModel> Login(string _Email, string _Password);
    }
}
