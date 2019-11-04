using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API
{
    public interface IUsuarioRepositorio
    {         
        Task<Usuario> Post(Usuario usuario);
    }
}
