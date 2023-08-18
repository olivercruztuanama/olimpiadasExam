using OLIMPIADAS.Dominio.DTO.Sedes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OLIMPIADAS.Dominio.Interfaces.Sis
{
    public interface IComplejoDeportivoRepository
    {
        Task<List<ComplejoDeportivoAdiDTO>> GetComplejoDeportivo();
        Task<List<ComplejoDeportivoAdiDTO>> SaveComplejoDeportivo(ComplejoDeportivoDTO obj);
        Task<List<ComplejoDeportivoAdiDTO>> DeleteComplejoDeportivo(int id);
    }
}
