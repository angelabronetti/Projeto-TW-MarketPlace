using System.Threading.Tasks;
using API.Models;
using API.ViewModel;

namespace API.Interfaces
{
    public interface ILogin
    {
        Task<string> Login(LoginViewModel loginView);
    }
}