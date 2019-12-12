using System.Threading.Tasks;
using Back_End_Completo.ViewModel;

namespace API.Interfaces
{
    public interface ILogin
    {
        Task<string> Login(LoginViewModel loginView);
    }
}