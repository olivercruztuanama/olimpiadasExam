using OLIMPIADAS.Dominio.DTO.Login;
using System.Threading.Tasks;

namespace OLIMPIADAS.Dominio.Interfaces.General
{
    public interface IGeneralRepository
    {
        Task<UsuariosDTO> AutentificarUsuario(string usuario, string password);
    }
}
