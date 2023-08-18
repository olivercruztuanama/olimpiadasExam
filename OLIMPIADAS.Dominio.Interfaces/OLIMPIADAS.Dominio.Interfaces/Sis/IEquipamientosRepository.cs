using OLIMPIADAS.Dominio.DTO.Sedes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OLIMPIADAS.Dominio.Interfaces.Sis
{
    public interface IEquipamientosRepository
    {
        Task<List<EquipamientosDTO>> GetEquipamientos();
    }
}
