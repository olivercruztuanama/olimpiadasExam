using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Dominio.DTO.Sedes
{
    public class TipoEventoDTO : EntityBase
    {
        public int IdTipoEvento { get; set; }
        public string Descripcion { get; set; }
    }
}