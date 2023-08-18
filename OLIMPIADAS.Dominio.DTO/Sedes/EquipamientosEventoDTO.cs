using OLIMPIADAS.Base.Core;

namespace EMPENIO.Dominio.DTO.Sedes
{
    public class EquipamientosEventoDTO : EntityBase
    {
        public int IdEquipamientosEvento { get; set; }
        public int IdEquipamiento { get; set; }
        public int IdEvento { get; set; }
    }
}
