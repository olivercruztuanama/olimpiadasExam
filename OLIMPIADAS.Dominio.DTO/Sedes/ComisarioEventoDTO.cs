using OLIMPIADAS.Base.Core;

namespace EMPENIO.Dominio.DTO.Sedes
{
    public class ComisarioEventoDTO : EntityBase
    {
        public int IdComisarioEvento { get; set; }
        public int IdComisario { get; set; }
        public int IdEvento { get; set; }
        public int IdTipoComisario { get; set; }
    }
}
