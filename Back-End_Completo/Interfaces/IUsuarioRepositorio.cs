using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> Get();
        Task<Usuario> Get(int id);
        Task<Usuario> Get(string nome);
        Task<Usuario> Post(Usuario usuario);
        Task<Usuario> Put(Usuario usuario);
        Task<Usuario> Delete(Usuario usuarioDel);
    }
}