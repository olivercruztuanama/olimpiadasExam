using OLIMPIADAS.Dominio.DTO.Sedes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OLIMPIADAS.Dominio.Interfaces.Sis
{
    public interface ISedesRepository
    {
        Task<List<SedesDTO>> GetSedes();
        Task<List<SedesDTO>> UpdateSede(SedesDTO obj);
        Task<List<SedesDTO>> DeleteSede(int id);
    }
}
